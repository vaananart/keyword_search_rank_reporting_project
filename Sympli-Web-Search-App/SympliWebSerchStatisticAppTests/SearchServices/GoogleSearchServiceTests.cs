using System.Threading.Tasks;

using SympliWebSearchStatisticApp.Services;
using SympliWebSearchStatisticApp.Utils.HttpSearchQueriers;
using SympliWebSearchStatisticApp.Utils.SearchPageScrapers;

using Xunit;

namespace SympliWebSerchStatisticAppTests.SearchServices
{
	public class GoogleSearchServiceTests
	{
		[Fact]
		public async void When_querying_google_search_engine_with_URL_Test()
		{
			ISearchService service = new SearchServiceFactory(new HttpQuerierFactory(), new SearchPageScraperFactory())
										.GetService("Google");

			Task<int?[]> result = service.RetrieveRanksByKeywordSearchAsync("e-settlement", "www.sympli.com");

			Task.WaitAll(result);

			Assert.Equal(1, result.Result[0]);
			Assert.Equal(2, result.Result[1]);

		}
	}
}
