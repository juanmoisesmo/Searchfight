using Searchfight.ApplicationCore.DTO;
using Searchfight.Infrastructure;
using Searchfight.Utility.ConfigurationSettings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.ApplicationCore
{
    public class SearchEngineLogic : ISearchEngineLogic
    {
        private readonly ISearchEngineService _searchEngineProxy;
        private readonly ConfigurationApplication _config;

        public SearchEngineLogic(Configuration config)
        {
            _searchEngineProxy = new SearchEngineService();
            _config = new ConfigurationApplication(config);
        }

        public string ProcessSearchFight(string searchQueryWord)
        {
            try
            {
                var wordHasQoutes = false;

                wordHasQoutes =  searchQueryWord.StartsWith("\"") && searchQueryWord.EndsWith("\"");

                wordHasQoutes = searchQueryWord.StartsWith("\'") && searchQueryWord.EndsWith("\'");

                wordHasQoutes = !wordHasQoutes ? searchQueryWord.StartsWith("\"") : wordHasQoutes;

                wordHasQoutes = !wordHasQoutes ? searchQueryWord.EndsWith("\"") : wordHasQoutes;

                wordHasQoutes = !wordHasQoutes ? searchQueryWord.StartsWith("\'") : wordHasQoutes;

                wordHasQoutes = !wordHasQoutes ? searchQueryWord.EndsWith("\'") : wordHasQoutes;

                if (wordHasQoutes)
                    searchQueryWord = searchQueryWord.Trim('\"');

                searchQueryWord = searchQueryWord.Trim();

                if (string.IsNullOrEmpty(searchQueryWord)) throw new ArgumentException("Please enter a word to search.");

                var result = ExecuteSearchEngineQueryWord(searchQueryWord, wordHasQoutes);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string ExecuteSearchEngineQueryWord(string queryWord, bool hasQoute = false)
        {
            try
            {
                var listQueryWordSearch = new List<string>();

                var listResultEngineSearch = new List<SearchEngineResultDto>();

                var sb = new StringBuilder();

                //validate if word has quotes, if has quotes will search as single word
                if (!hasQoute)
                    queryWord.Split(" ").ToList().ForEach(x => listQueryWordSearch.Add(x));
                else
                    listQueryWordSearch.Add(queryWord);

                var listSearchEngines = _config.ListSearchEnginesConfiguration("SEARCH_ENGINES");


                Parallel.ForEach(listQueryWordSearch, (item) =>
                {
                    Parallel.ForEach(listSearchEngines, (e) =>
                    {
                        var engineName = _config.GetValueConfigSettings("SEARCH_ENGINES", e, "NAME");
                        var engineUrl = _config.GetValueConfigSettings("SEARCH_ENGINES", e, "URL");

                        var tagStartSplit = _config.GetValueConfigSettings("SEARCH_ENGINES", e, "TAG_START_SPLIT");
                        var tagEndSplit = _config.GetValueConfigSettings("SEARCH_ENGINES", e, "TAG_END_SPLIT");

                        var posArrayStartSplit = _config.GetValueConfigSettings("SEARCH_ENGINES", e, "POS_ARRAY_START_SPLIT");
                        var posArrayEndSplit = _config.GetValueConfigSettings("SEARCH_ENGINES", e, "POS_ARRAY_END_SPLIT");

                        var iPosArrayStartSplit = string.IsNullOrEmpty(posArrayStartSplit) ? 1 : Convert.ToInt32(posArrayStartSplit);
                        var iPosArrayEndSplit = string.IsNullOrEmpty(posArrayEndSplit) ? 0 : Convert.ToInt32(posArrayEndSplit);

                        var resultEngine = _searchEngineProxy.GetDataFromSearchEngine(string.Format(engineUrl, item), tagStartSplit, tagEndSplit, iPosArrayStartSplit, iPosArrayEndSplit);

                        listResultEngineSearch.Add(new SearchEngineResultDto { EngineName = e, EngineFullName = engineName, WordSearch = item, Quantity = Convert.ToInt64(resultEngine) });

                    });
                });

                sb.AppendLine("******************** SEARCH ENGINE RESULTS BY WORD ********************");
                sb.AppendLine("");

                listQueryWordSearch.ForEach(item =>
                {
                    sb.Append($"{item}: ");

                    listResultEngineSearch.ForEach(e =>
                    {
                        if (item == e.WordSearch)
                            sb.Append($"{e.EngineFullName}: {e.Quantity} ");
                    });

                    sb.AppendLine();
                });

                sb.AppendLine("");
                sb.AppendLine("******************** WINNER WORD BY SEARCH ENGINE********************");
                sb.AppendLine("");

                listSearchEngines.ForEach(item =>
                {
                    var lstresultbyengine = listResultEngineSearch.FindAll(x => x.EngineName == item);
                    var querysearchenginewinner = lstresultbyengine.FirstOrDefault(x => x.Quantity == lstresultbyengine.Max(m => m.Quantity));

                    sb.AppendLine($"{querysearchenginewinner.EngineFullName} winner: {querysearchenginewinner.WordSearch} ");
                });

                sb.AppendLine("");
                sb.AppendLine("******************** TOTAL WINNER ALL SEARCH ENGINES ********************");
                sb.AppendLine("");

                var totalQuerySearchWinner = listResultEngineSearch.FirstOrDefault(x => x.Quantity == listResultEngineSearch.Max(m => m.Quantity));

                sb.AppendLine($"Total winner: {totalQuerySearchWinner.WordSearch}");

                return sb.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
