using InteractiveApiRisovaviti.Interface;
using System;
using System.Net.Http.Headers;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class ApiGet : ApiRequest
	{
		public ApiGet(IAuthenticationUser user) : base(user)
		{
		}

		protected override HttpResponseMessage ExecutingRequest(HttpClient client)
		{
			HttpResponseMessage message = client.GetAsync(Url).Result;
			return message;
		}
	}
}
