using DomainModel.Model;
using InteractiveApiRisovaviti.Interface;
using System.Net.Http.Headers;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal abstract class ApiRequest : IApiRequest
	{
		private IAuthenticationUser _user;
		protected Uri Url {  get; private set; }

		public ApiRequest(IAuthenticationUser user)
		{
			_user = user;
			this.Url = new Uri(String.Empty);
		}

		public HttpResponseMessage GetRequest(string url)
		{
			Url = new Uri(url);
			var client = OptionRequst();
			return ExecutingRequest(client);
		}

		protected abstract HttpResponseMessage ExecutingRequest(HttpClient request);

		protected virtual HttpClient OptionRequst()
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
