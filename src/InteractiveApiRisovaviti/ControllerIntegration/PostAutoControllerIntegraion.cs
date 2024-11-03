using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
    internal class PostAutoControllerIntegraion<T> : PostControllerIntegration<T>, IPostAutoControllerIntegraion
	{
		string Url { get; set; } = string.Empty;
		public PostAutoControllerIntegraion(IAuthenticationUser user, T value) : base(user, value) { }

		public T2 GetResult<T2>(string url)
		{
			Url = url;
			var message = GetResponseMessage();
			CheckStatusCode(message);
			return message.Content.ReadAsAsync<T2>().Result;
		}

		public void ExecuteReques(string url)
		{
			Url = url;
			CheckStatusCode(GetResponseMessage());
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest(Url);
		}
	}
}
