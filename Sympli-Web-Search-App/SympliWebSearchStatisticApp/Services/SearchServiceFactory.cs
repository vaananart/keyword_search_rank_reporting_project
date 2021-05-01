using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

using SympliWebSearchStatisticApp.Utils.Enums;
using SympliWebSearchStatisticApp.Utils.HttpSearchQueriers;
using SympliWebSearchStatisticApp.Utils.SearchPageScrapers;
using SympliWebSearchStatisticApp.Utils.StringSupport;

namespace SympliWebSearchStatisticApp.Services
{
	public class SearchServiceFactory : ISearchServiceFactory
	{
		private readonly IDictionary<string, ISearchService> _searchServiceLookup;
		private readonly IHttpQuerierFactory _httpQuerierFactory;
		private readonly ISearchPageScraperFactory _searchPageScraperFactory;

		public SearchServiceFactory(IHttpQuerierFactory httpQuerierFactory
									, ISearchPageScraperFactory searchPageScraperFactory) 
		{
			this._searchServiceLookup = new ConcurrentDictionary<string, ISearchService>();
			this._httpQuerierFactory = httpQuerierFactory;
			this._searchPageScraperFactory = searchPageScraperFactory;
			
		}

		public ISearchService GetService(string searchEngineName)
		{
			var matchedResult = this._searchServiceLookup[searchEngineName.ToLower().Normalize()];

			if (matchedResult != null)
				return matchedResult;

			var querier = this._httpQuerierFactory.GetQuerierBySearchEngineName(searchEngineName);
			var scraper = this._searchPageScraperFactory.GetScraper(searchEngineName);

			switch (searchEngineName.ToLower().Normalize())
			{
				case "google":
					this._searchServiceLookup["google"] = new GoogleSearchService(querier
																					, scraper);
					return this._searchServiceLookup["google"];
				default:
					return null;
			}
		}

		public ISearchService GetService(EngineEnum searchEngine)
		{
			var matchedResult = this._searchServiceLookup[searchEngine.ToNormalisedString()];

			if (matchedResult != null)
				return matchedResult;

			var querier = this._httpQuerierFactory.GetQuerierBySearchEngineName(searchEngine);
			var scraper = this._searchPageScraperFactory.GetScraper(searchEngine);

			switch (searchEngine)
			{
				case EngineEnum.Google:
					this._searchServiceLookup[EngineEnum.Google.ToNormalisedString()] = new GoogleSearchService(querier
																					, scraper);
					return this._searchServiceLookup[EngineEnum.Google.ToNormalisedString()];
				default:
					return null;
			}
		}
	}
}
