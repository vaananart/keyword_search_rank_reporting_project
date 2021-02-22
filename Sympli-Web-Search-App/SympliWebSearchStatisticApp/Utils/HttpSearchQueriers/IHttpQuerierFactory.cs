namespace SympliWebSearchStatisticApp.Utils.HttpSearchQueriers
{
	public interface IHttpQuerierFactory
	{
		IHttpQuerier GetQuerierBySearchEngineName(string searchEngineName);
	}
}
