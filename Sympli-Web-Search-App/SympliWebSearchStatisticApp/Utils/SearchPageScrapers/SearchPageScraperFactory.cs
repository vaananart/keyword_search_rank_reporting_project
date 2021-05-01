using System.Collections.Generic;
using System.Linq;

using SympliWebSearchStatisticApp.Utils.Enums;
using SympliWebSearchStatisticApp.Utils.StringSupport;

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
			var matchedResult = this._pageScraperLookUp[searchEngineName.ToLower().Normalize()];

			if (matchedResult != null)
				return matchedResult;

			switch (searchEngineName.ToLower().Normalize())
			{
				case "google":
					this._pageScraperLookUp[EngineEnum.Google.ToNormalisedString()] = new GoogleSearchPageScraper();
					return this._pageScraperLookUp[EngineEnum.Google.ToNormalisedString()];
				default:
					return null;
			}

		}

		public ISearchPageScraper GetScraper(EngineEnum searchEngine)
		{
			throw new System.NotImplementedException();
		}
	}
}
