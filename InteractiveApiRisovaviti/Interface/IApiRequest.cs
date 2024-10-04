
namespace InteractiveApiRisovaviti.Interface
{
	internal interface IApiRequest
	{
		HttpResponseMessage GetRequest(string url);
	}
}
