using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.ProfileController 
{
	class EditPasswordControllerIntegraion : PostControllerIntegration<EditPasswordResult>
	{
		public EditPasswordControllerIntegraion(IAuthenticationUser user, EditPasswordResult value) : base(user, value)
		{}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("");
		}
	}
}

