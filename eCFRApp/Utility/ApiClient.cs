using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eCFRAnalyis.Utility
{
	public static class ApiClient
	{
		private static HttpClient _httpClient;

		public static HttpClient GetApiClient(string baseAddress)
		{
			_httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return _httpClient;
		}
	}
}
