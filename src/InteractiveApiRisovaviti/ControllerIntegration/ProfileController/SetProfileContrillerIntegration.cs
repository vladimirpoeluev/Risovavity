using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.ProfileController
{
	internal class SetProfileContrillerIntegration : PostControllerIntegration<UserResult>, ISetProfileControllerIntegration
	{
		public SetProfileContrillerIntegration(IAuthenticationUser user) : base(user, new UserResult()) {}

		public void SetProfile(UserResult profile)
		{
			Value = profile;
			var message = GetResponseMessage();
			CheckStatusCode(message);
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("api/profile/setprofile");
		}
	}
}
