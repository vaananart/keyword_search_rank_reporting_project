
using SympliWebSearchStatisticApp.Utils.SearchPageScrapers;

using SympliWebSerchStatisticAppTests.Util;

using Xunit;

namespace SympliWebSerchStatisticAppTests
{
	public class GoogleSearchPageScraperTests
	{
		[Fact]
		public void When_scanning_for_URL_from_the_received_payload_Test()
		{
			//NOTE: the url used to search : https://www.google.com/search?q=e-settlement&num=100

			var lines = TestSampleDataExtractor.Extract("sample.html.txt");
			var combinedString = string.Concat(lines);

			ISearchPageScraperFactory scraperFactory = new SearchPageScraperFactory();

			var scraper = scraperFactory.GetScraper("Google");
			var result = scraper.GetRanksByKeyWordSearch("www.sympli.com", combinedString);

			Assert.Equal(1, result[0]);
			Assert.Equal(2, result[1]);
		}
	}
}
