using Searchfight.ApplicationCore;
using System;
using System.Configuration;

namespace Searchfight
{
    class Program
    {
        static void Main(string[] args)
        {      
            Console.Clear();

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter a word to search.");
                return;
            }

            Console.WriteLine("Searching data............  Please wait.........");

            var searchQueryWord = string.Empty;

            foreach (var arg in args)
                searchQueryWord += arg + " ";

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ISearchEngineLogic searchEngineLogic = new SearchEngineLogic(config);
            var resultsEngineSearch = searchEngineLogic.ProcessSearchFight(searchQueryWord);
            
            Console.Clear();
            Console.WriteLine(resultsEngineSearch);
        }
    }
}
