using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SympliWebSearchStatisticApp.Services.Models;
using SympliWebSearchStatisticApp.Utils.HttpSearchQueriers;
using SympliWebSearchStatisticApp.Utils.SearchPageScrapers;

namespace SympliWebSearchStatisticApp.Services
{
	public class GoogleSearchService : ISearchService
	{
		private readonly IHttpQuerier _httpQuerier;
		private readonly ISearchPageScraper _searchPageScraper;

		public GoogleSearchService(IHttpQuerierFactory httpQuerierFactory, ISearchPageScraperFactory searchPageScraperFactory)
		{
			this._httpQuerier = httpQuerierFactory.GetQuerierBySearchEngineName("Google");
			this._searchPageScraper = searchPageScraperFactory.GetScraper("Google");
			this.CachedResult = new List<CachedRankModel>();
		}

		public IList<CachedRankModel> CachedResult { get; set; }

		public async Task<int?[]> RetrieveRanksByKeywordSearchAsync(string proxySearchparam, string rankKeywordSearch)
		{
			var cachedMatch = CacheMatchedValue(proxySearchparam, rankKeywordSearch);
			if (cachedMatch != null && DateTime.UtcNow < cachedMatch.LastQueriedDateTime.AddHours(1))
				return cachedMatch.RankResult;
			
			string queriedResult = string.Empty;
			try
			{
				Task<string>  task = this._httpQuerier.QueryBySearchKeywordAsync(proxySearchparam);
				queriedResult = await task;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}

			var rankResult = this._searchPageScraper.GetRanksByKeyWordSearch(rankKeywordSearch, queriedResult);

			if (cachedMatch == null)
			{
				CachedResult.Add(new CachedRankModel
				{
					EngineName = "google",
					KeyWordSearch = proxySearchparam,
					RankWordSearch = rankKeywordSearch,
					RankResult = rankResult,
					LastQueriedDateTime = DateTime.UtcNow
				}) ;
			}
			else
			{
				CachedResult.Remove(cachedMatch);
				cachedMatch.RankResult = rankResult;
				cachedMatch.LastQueriedDateTime = DateTime.UtcNow;
				CachedResult.Add(cachedMatch);
			}

			return rankResult;
		}

		private CachedRankModel CacheMatchedValue(string proxySearchparam, string rankKeywordSearch)
		{
			var matchedElement = CachedResult
								.Where(x=>x.EngineName == "google" 
										&& x.KeyWordSearch == proxySearchparam 
										&& x.RankWordSearch == rankKeywordSearch).FirstOrDefault();
			return matchedElement;
		}
	}
}