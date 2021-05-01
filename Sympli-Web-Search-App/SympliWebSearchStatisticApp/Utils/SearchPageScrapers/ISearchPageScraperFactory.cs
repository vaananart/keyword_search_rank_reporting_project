using SympliWebSearchStatisticApp.Utils.Enums;

namespace SympliWebSearchStatisticApp.Utils.SearchPageScrapers
{
	public interface ISearchPageScraperFactory
	{
		ISearchPageScraper GetScraper(string searchEngineName);
		ISearchPageScraper GetScraper(EngineEnum searchEngine);
	}
}
