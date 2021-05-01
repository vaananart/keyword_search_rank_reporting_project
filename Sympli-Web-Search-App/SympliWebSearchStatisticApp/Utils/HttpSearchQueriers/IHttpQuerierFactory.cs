using SympliWebSearchStatisticApp.Utils.Enums;

namespace SympliWebSearchStatisticApp.Utils.HttpSearchQueriers
{
	public interface IHttpQuerierFactory
	{
		IHttpQuerier GetQuerierBySearchEngineName(string searchEngineName);

		IHttpQuerier GetQuerierBySearchEngineName(EngineEnum searchEngine);
	}
}
