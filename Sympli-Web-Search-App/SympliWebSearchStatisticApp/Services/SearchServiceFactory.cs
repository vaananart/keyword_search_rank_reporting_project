using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SympliWebSearchStatisticApp.Utils.HttpSearchQueriers;
using SympliWebSearchStatisticApp.Utils.SearchPageScrapers;

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
			this._searchServiceLookup = new Dictionary<string, ISearchService>();
			this._httpQuerierFactory = httpQuerierFactory;
			this._searchPageScraperFactory = searchPageScraperFactory;
			
		}

		public ISearchService GetService(string searchEngineName)
		{
			var matchedResult = this._searchServiceLookup
									.Where(x => x.Key == searchEngineName.ToLower().Normalize())
									.FirstOrDefault().Value;

			if (matchedResult != null)
				return matchedResult;

			switch (searchEngineName.ToLower().Normalize())
			{
				case "google":
					this._searchServiceLookup["google"] = new GoogleSearchService(this._httpQuerierFactory
																					, this._searchPageScraperFactory);
					return this._searchServiceLookup["google"];
				default:
					return null;
			}
		}
	}
}
