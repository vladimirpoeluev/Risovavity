
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.AvatarUsers
{
	internal class AvatarUsersControllerIntegration : GetControllerIntegration, IAvatarUsersControllerIntegration
	{
		int Id { get; set; }	
		public AvatarUsersControllerIntegration(IAuthenticationUser user) : base(user) {}

		public UserAvatarResult GetAvatarResult(int id)
		{
			Id = id;
			var message = GetResponseMessage();
			CheckStatusCode(message);
			return message.Content.ReadAsAsync<UserAvatarResult>().Result;
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest($"api/AvatarUsers?id={Id}");
		}
	}
}
