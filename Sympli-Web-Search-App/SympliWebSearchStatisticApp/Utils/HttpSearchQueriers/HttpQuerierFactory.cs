using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using SympliWebSearchStatisticApp.Utils.Enums;

namespace SympliWebSearchStatisticApp.Utils.HttpSearchQueriers
{
	public class HttpQuerierFactory : IHttpQuerierFactory
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IDictionary<string, IHttpQuerier> _httpQuerierLookUp;

		public HttpQuerierFactory(IHttpClientFactory httpClientFactory)
		{
			this._httpClientFactory = httpClientFactory;
			this._httpQuerierLookUp = new Dictionary<string, IHttpQuerier>();
		}

		public IHttpQuerier GetQuerierBySearchEngineName(string searchEngineName)
		{
			var matchedResult = this._httpQuerierLookUp[searchEngineName.ToLower().Normalize()];

			if (matchedResult != null)
				return matchedResult;

			switch (searchEngineName.ToLower().Normalize())
			{
				case "google":
					this._httpQuerierLookUp["google"] = new GoogleSearchQuerier(this._httpClientFactory.CreateClient());
					return this._httpQuerierLookUp["google"];
				default:
					return null;
			}
		}

		public IHttpQuerier GetQuerierBySearchEngineName(EngineEnum searchEngine)
		{
			throw new System.NotImplementedException();
		}
	}
}
