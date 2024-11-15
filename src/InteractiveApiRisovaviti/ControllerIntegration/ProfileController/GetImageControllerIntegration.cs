
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.ProfileController
{
	internal class GetImageControllerIntegration : GetControllerIntegration, IGetImageControllerIntegration
	{
		public GetImageControllerIntegration(IAuthenticationUser user) : base(user)
		{
		}

		public UserAvatarResult GetUserAvatar()
		{
			var message = GetResponseMessage();
			CheckStatusCode(message);
			return message.Content.ReadAsAsync<UserAvatarResult>().Result;
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest("api/profile/getimage/");
		}

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}
