using InteractiveApiRisovaviti.Interface;
using System.Net.Http.Headers;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class ApiGet : IApiGet
	{
		private IAuthenticationUser _user;

		public ApiGet(IAuthenticationUser user)
		{
			_user = user;
		}

		public ApiGet() 
		{
			_user = new AuthenticationUser(String.Empty);
		}

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
			_user.SettingUpDataProvisioning(client);

			return client;
		}
	}
}
