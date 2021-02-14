using System.Collections.Generic;
using System.Linq;

namespace SympliWebSearchStatisticApp.Utils.HttpSearchQueriers
{
	public class HttpQuerierFactory : IHttpQuerierFactory
	{
		private readonly IDictionary<string, IHttpQuerier> _httpQuerierLookUp;

		public HttpQuerierFactory()
		{
			this._httpQuerierLookUp = new Dictionary<string, IHttpQuerier>();
		}

		public IHttpQuerier GetQuerierBySearchEngineName(string searchEngineName)
		{
			var matchedResult = this._httpQuerierLookUp
									.Where(x=>x.Key == searchEngineName.ToLower().Normalize())
									.FirstOrDefault().Value;

			if (matchedResult != null)
				return matchedResult;

			switch (searchEngineName.ToLower().Normalize())
			{
				case "google":
					this._httpQuerierLookUp["google"] = new GoogleSearchQuerier();
					return this._httpQuerierLookUp["google"];
				default:
					return null;
			}
		}
	}
}
