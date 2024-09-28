
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InteractiveApiRisovaviti
{
	internal class EntranceControllerIntegration : IEntranceControllerIntegration
	{
		public Guid GetCode(string login, string password)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri("https://localhost:7281/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage message = client.GetAsync($"api/Entrance/input?login={login}&password={password}").Result;

			if (message.StatusCode == HttpStatusCode.OK)
			{
				var result = message.Content.ReadAsAsync<Guid>().Result;
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
