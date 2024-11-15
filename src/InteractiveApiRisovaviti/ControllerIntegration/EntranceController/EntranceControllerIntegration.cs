using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.EntranceController
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
            var result = message.Content.ReadAsAsync<string>().Result;
            return result;
        }

        protected override HttpResponseMessage StartRequest(IApiRequest client)
        {
            return client.GetRequest($"api/Entrance/input?login={Login}&password={Password}");
        }

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}
