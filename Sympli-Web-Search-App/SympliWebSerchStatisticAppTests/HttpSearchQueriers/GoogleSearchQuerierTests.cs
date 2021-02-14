using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SympliWebSearchStatisticApp.Utils.HttpSearchQueriers;

using Xunit;

namespace SympliWebSerchStatisticAppTests.HttpSearchQueriers
{
	public class GoogleSearchQuerierTests
	{
		[Fact]
		public void Given_keyword_to_search_When_querying_for_matched_result_page_from_google_search_engine_Test()
		{
			IHttpQuerierFactory querierFactory = new HttpQuerierFactory();

			var googleQuerier = querierFactory.GetQuerierBySearchEngineName("Google");
			var result = googleQuerier.QueryBySearchKeywordAsync("e-settlement");

			Task.WaitAll(result);

			Assert.True(result.Result != string.Empty);

		}
	}
}
