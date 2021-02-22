using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SympliWebSearchStatisticApp.Utils.HttpSearchQueriers
{
	public class GoogleSearchQuerier : IHttpQuerier
	{
		private readonly HttpClient _httpClient;
		public GoogleSearchQuerier()
		{
			this._httpClient = new HttpClient();
		}

		public async Task<string> QueryBySearchKeywordAsync(string search)
		{
			string url = "http://www.google.com/search?q="+search+"&num=100";
			HttpRequestMessage message = new HttpRequestMessage();
			
			message.Headers.Add("Accept", "text/html");
			message.RequestUri = new Uri(url);

			var response = await this._httpClient.SendAsync(message);

			if (response.StatusCode == HttpStatusCode.TooManyRequests)
				throw new Exception(response.ReasonPhrase);

			var result = await response.Content.ReadAsStringAsync();

			return await Task.FromResult(result);
		}
	}
}
