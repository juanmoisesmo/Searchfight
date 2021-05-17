using Searchfight.Utility.Functions;
using System;

namespace Searchfight.Infrastructure
{
    public class SearchEngineService : ISearchEngineService
    {
        public string GetDataFromSearchEngine(string url, string tagStartSplit, string tagEndSplit, int posArrayStartSplit = 1, int posArrayEndSplit = 0)
        {
            try
            {
                using var httpFuncions = new HttpFunctions();
                var resultSearchData = httpFuncions.ExecuteDynamicSearchEngineAsync(url).Result;

                tagStartSplit = StringFunctions.ParseTagValueToHtmlTag(tagStartSplit);
                tagEndSplit = StringFunctions.ParseTagValueToHtmlTag(tagEndSplit);

                var rs = StringFunctions.ParserDataResultsSearch(resultSearchData, tagStartSplit, tagEndSplit, posArrayStartSplit, posArrayEndSplit);

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
