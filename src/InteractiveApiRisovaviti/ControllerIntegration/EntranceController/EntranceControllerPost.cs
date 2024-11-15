using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.EntranceController
{
    internal class EntranceControllerPost : PostControllerIntegration<AuthenticationForm>, IEntranceControllerIntegration
    {
        public EntranceControllerPost(IAuthenticationUser user) : base(user, new AuthenticationForm())
        {
        }

        public string EntranceSystem(string login, string password)
        {
            Value.Login = login;
            Value.Password = password;
            var message = GetResponseMessage();
            CheckStatusCode(message);
            return message.Content.ReadAsAsync<string>().Result;
        }

        protected override HttpResponseMessage StartRequest(IApiRequest client)
        {
            return client.GetRequest("api/Entrance/input");
        }

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}
