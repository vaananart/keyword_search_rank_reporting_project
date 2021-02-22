namespace SympliWebSearchStatisticApp.Services
{
	public interface ISearchServiceFactory
	{
		ISearchService GetService(string searchEngineName);
	}
}
