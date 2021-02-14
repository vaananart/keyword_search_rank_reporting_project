namespace SympliWebSearchStatisticApp.Utils.SearchPageScrapers
{
	public interface ISearchPageScraperFactory
	{
		ISearchPageScraper GetScraper(string searchEngineName);
	}
}
