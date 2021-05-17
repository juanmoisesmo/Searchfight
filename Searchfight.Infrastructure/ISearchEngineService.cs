namespace Searchfight.Infrastructure
{
    public interface ISearchEngineService
    {
        string GetDataFromSearchEngine(string url, string tagStartSplit, string tagEndSplit, int posArrayStartSplit = 1, int posArrayEndSplit = 0);
    }
}
