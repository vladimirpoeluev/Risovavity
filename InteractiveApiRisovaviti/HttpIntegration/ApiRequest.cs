using DomainModel.Model;
using InteractiveApiRisovaviti.Interface;
using System.Net.Http.Headers;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal abstract class ApiRequest : IApiRequest
	{
		public IAuthenticationUser User { get; set; }
		protected string Url {  get; private set; }

		public ApiRequest(IAuthenticationUser user) : this()
		{
			User = user;
			
		}

		public ApiRequest() 
		{
			User = new AuthenticationUser(String.Empty);
			this.Url = string.Empty;
		}

		public HttpResponseMessage GetRequest(string url)
		{
			Url = url;
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
			User.SettingUpDataProvisioning(client);

			return client;
		}
	}
}
