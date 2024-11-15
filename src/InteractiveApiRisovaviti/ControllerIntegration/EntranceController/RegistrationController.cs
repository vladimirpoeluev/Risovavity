using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.EntranceController
{
	internal class RegistrationController : PostControllerIntegration<RegistrationForm>, IRegistraionController
	{
		public RegistrationController(IAuthenticationUser user) : base(user, new RegistrationForm())
		{
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("api/Entrance/regist");
		}

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}

		void IRegistraionController.RegistrationSystem(RegistrationForm form)
		{
			Value = form;
			CheckStatusCode(GetResponseMessage());
		}
	}
}
