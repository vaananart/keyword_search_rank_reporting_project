using SympliWebSearchStatisticApp.Utils.Enums;

namespace SympliWebSearchStatisticApp.Services
{
	public interface ISearchServiceFactory
	{
		ISearchService GetService(string searchEngineName);

		ISearchService GetService(EngineEnum searchEngine);
	}
}
