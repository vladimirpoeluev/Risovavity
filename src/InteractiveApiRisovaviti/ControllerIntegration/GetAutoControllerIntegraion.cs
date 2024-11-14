
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
    internal class GetAutoControllerIntegraion : GetControllerIntegration, IGetAutoControllerIntegraion
	{
		string Url { get; set; } = string.Empty;

		public GetAutoControllerIntegraion(IAuthenticationUser user) : base(user) { }

		public T GetResult<T>(string url)
		{
			Url = url;
			var message = GetResponseMessage();
			CheckStatusCode(message);
			return message.Content.ReadAsAsync<T>().Result;
		}

		public async Task<T> GetResultAsync<T>(string url)
		{
			Url = url;
			var message = await GetResponseAsync();
			CheckStatusCode(message);
			return await message.Content.ReadAsAsync<T>();
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest(Url);
		}

		protected override async Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			return await client.GetRequestAsync(Url);
		}

	}
}
