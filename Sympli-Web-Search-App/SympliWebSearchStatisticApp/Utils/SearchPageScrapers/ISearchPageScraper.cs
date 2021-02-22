namespace SympliWebSearchStatisticApp.Utils.SearchPageScrapers
{
	public interface ISearchPageScraper
	{
		string Name { get; }
		int?[] GetRanksByKeyWordSearch(string keyWord, string htmlContent);
	}
}
