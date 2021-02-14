using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SympliWebSearchStatisticApp.Utils.SearchPageScrapers
{
	public interface ISearchPageScraper
	{
		int?[] GetRanksByKeyWordSearch(string keyWord, string htmlContent);
	}
}
