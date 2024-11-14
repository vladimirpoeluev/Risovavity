
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class ApiPost<T> : ApiRequest
	{
		public T SetterValue { get; set; }

		public ApiPost(IAuthenticationUser user, T setter) : base(user) 
		{
			SetterValue = setter;
		}
		protected override HttpResponseMessage ExecutingRequest(HttpClient request)
		{
			return request.PostAsJsonAsync(Url, SetterValue).Result;
		}

		protected override async Task<HttpResponseMessage> ExecutingRequestAsync(HttpClient request)
		{
			return await request.PostAsJsonAsync(Url, SetterValue);
		}
	}
}
