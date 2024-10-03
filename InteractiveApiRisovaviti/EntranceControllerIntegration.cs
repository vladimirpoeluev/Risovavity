
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using InteractiveApiRisovaviti.HttpIntegration;

namespace InteractiveApiRisovaviti
{
	internal class EntranceControllerIntegration : IEntranceControllerIntegration
	{
		public string EntranceSystem(string login, string password)
		{
			HttpResponseMessage message = new ApiGet().GetRequest($"api/Entrance/input?login={login}&password={password}");

			if (message.StatusCode == HttpStatusCode.OK)
			{
				var result = message.Content.ReadAsAsync<string>().Result;
				return result;
			}
			else
			{
				string result = message.Content.ReadAsAsync<string>().Result;
				throw new Exception($"Code: {(int)message.StatusCode} Message: {result}");
			}
		}

	}
}
