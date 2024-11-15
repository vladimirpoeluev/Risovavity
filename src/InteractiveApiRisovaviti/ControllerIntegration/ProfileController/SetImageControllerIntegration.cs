using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.ProfileController
{
	internal class SetImageControllerIntegration : PostControllerIntegration<UserAvatarResult>, ISetImageControllerIntegration
	{
		public SetImageControllerIntegration(IAuthenticationUser user) : base(user, new UserAvatarResult()) {}

		public void SetImage(UserAvatarResult userAvatarResult)
		{
			Value = userAvatarResult;
			CheckStatusCode(GetResponseMessage());
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("api/profile/setimage");
		}

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}
