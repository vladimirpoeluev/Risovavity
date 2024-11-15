using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.ProfileController 
{
	class EditPasswordControllerIntegraion : PostControllerIntegration<EditPasswordResult>, IEditerPasswordControllerIntegration
	{
		public EditPasswordControllerIntegraion(IAuthenticationUser user) : base(user, new EditPasswordResult())
		{}

		public void PasswordEdit(EditPasswordResult result)
		{
			Value = result;
			CheckStatusCode(GetResponseMessage());
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("api/Profile/passwordEdit");
		}

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}

