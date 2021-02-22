using System.Collections.Generic;
using System.Linq;

namespace SympliWebSearchStatisticApp.Utils.SearchPageScrapers
{
	public class SearchPageScraperFactory : ISearchPageScraperFactory
	{
		private readonly IDictionary<string, ISearchPageScraper> _pageScraperLookUp;

		public SearchPageScraperFactory()
		{
			this._pageScraperLookUp = new Dictionary<string, ISearchPageScraper>();
		}

		public ISearchPageScraper GetScraper(string searchEngineName)
		{
			var matchedResult = this._pageScraperLookUp
									.Where(x=>x.Key == searchEngineName.ToLower().Normalize())
									.FirstOrDefault().Value;

			if (matchedResult != null)
				return matchedResult;

			switch (searchEngineName.ToLower().Normalize())
			{
				case "google":
					this._pageScraperLookUp["google"] = new GoogleSearchPageScraper();
					return this._pageScraperLookUp["google"];
				default:
					return null;
			}

		}
	}
}
