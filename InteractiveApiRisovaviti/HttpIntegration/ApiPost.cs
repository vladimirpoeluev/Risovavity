

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
			return request.PutAsJsonAsync<T>(Url, SetterValue).Result;
		}
	}
}
