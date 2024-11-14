using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class ApiGet : ApiRequest
	{
		public ApiGet(IAuthenticationUser user) : base(user)
		{
		}

		public ApiGet() : base() { }

		protected override HttpResponseMessage ExecutingRequest(HttpClient client)
		{
			HttpResponseMessage message = client.GetAsync(Url).Result;
			return message;
		}

		protected override async Task<HttpResponseMessage> ExecutingRequestAsync(HttpClient client)
		{
			var message = await client.GetAsync(Url);
			return message;
		}
	}
}
