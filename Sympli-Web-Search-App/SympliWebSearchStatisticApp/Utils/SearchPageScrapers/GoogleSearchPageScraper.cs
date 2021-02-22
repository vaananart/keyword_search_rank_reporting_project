using System.Collections.Generic;
using System.Linq;

using HtmlAgilityPack;

namespace SympliWebSearchStatisticApp.Utils.SearchPageScrapers
{
	public class GoogleSearchPageScraper : ISearchPageScraper
	{
		private readonly HtmlDocument _htmlDocumentReader;
		public GoogleSearchPageScraper()
		{
			this._htmlDocumentReader = new HtmlDocument();
		}

		public string Name { get =>  "GoogleSearchPageScrapper"; }

		public int?[] GetRanksByKeyWordSearch(string keyWord, string htmlContent)
		{

			this._htmlDocumentReader.LoadHtml(htmlContent);
			var result = this._htmlDocumentReader.DocumentNode.SelectNodes("//*[@id=\"main\"]/div[*]/div/div/a");

			if (result == null)
				return null;

			var firstNode = result[0];
			if (firstNode.Attributes["href"].Value.Contains("www.google.com"))
				result.RemoveAt(0);

			IList<int?> rankIndex = new List<int?>();
			var size = result.Count();
			for (int i = 0; i < size; i++)
			{
				var node = result.ElementAt(i);
				var urlString = node.Attributes["href"].Value;
				if (urlString.Contains(keyWord))
					rankIndex.Add(i);
			}

			return rankIndex.ToArray();
		}
	}
}
