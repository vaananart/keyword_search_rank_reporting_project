using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

using SympliWebSearchStatisticApp.Services.Models;

namespace SympliWebSearchStatisticApp.Services
{
	public interface ISearchService
	{
		public ConcurrentBag<CachedRankModel> CachedResult { get; set; }

		Task<int?[]> RetrieveRanksByKeywordSearchAsync(string proxySearchparam, string rankKeywordSearch);
	}
}
