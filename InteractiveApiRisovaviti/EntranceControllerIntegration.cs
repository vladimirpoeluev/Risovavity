
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DomainModel.ResultsRequest.Error;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
    internal class EntranceControllerIntegration : GetControllerIntegration, IEntranceControllerIntegration
	{
		private string Password { get; set; } = string.Empty;
		private string Login { get; set; } = string.Empty;

		public EntranceControllerIntegration(IAuthenticationUser user) : base(user)
		{

		}

		public string EntranceSystem(string login, string password)
		{
			Login = login;
			Password = password;
			HttpResponseMessage message = GetResponseMessage();
			CheckStatusCode(message);
			var result = message.Content.ReadAsStringAsync().Result;
			return result;
		}

		private void CheckStatusCode(HttpResponseMessage message)
		{
			if (message.StatusCode != HttpStatusCode.OK)
			{
				var result = message.Content.ReadAsStringAsync().Result;
				throw new Exception($"Code: {(int)message.StatusCode} Message: {result}");
			}
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest($"api/Entrance/input?login={Login}&password={Password}");
		}
	}
}
