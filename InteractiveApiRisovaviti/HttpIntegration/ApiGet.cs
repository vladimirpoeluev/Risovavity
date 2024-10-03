using InteractiveApiRisovaviti.Interface;
using System.Net.Http.Headers;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class ApiGet : IApiGet
	{
		public HttpResponseMessage GetRequest(string url)
		{
			HttpClient client = SettingClient();
			HttpResponseMessage message = client.GetAsync(url).Result;
			return message;
		}

		private HttpClient SettingClient()
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = OptionsApiRequest.BaseAddress;
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}
	}
}
