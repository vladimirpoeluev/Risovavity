
namespace InteractiveApiRisovaviti.Interface
{
	internal interface IApiRequest
	{
		IAuthenticationUser User { get; set; }
		HttpResponseMessage GetRequest(string url);
		Task<HttpResponseMessage> GetRequestAsync(string url);
	}
}
