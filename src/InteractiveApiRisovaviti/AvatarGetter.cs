using DomainModel.Integration;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.ControllerIntegration.AvatarUsers;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class AvatarGetter : IUserAvatarGetter
	{
		IAvatarUsersControllerIntegration _getterAvatar;
		IGetAutoControllerIntegraion _controllerIntegration;

		public AvatarGetter(IAuthenticationUser user)
		{
			_getterAvatar = new AvatarUsersControllerIntegration(user);
			_controllerIntegration = new GetAutoControllerIntegraion(user);
		}

		public async Task<UserAvatarResult> GetAvatarUserAsync(int id)
		{
			return await _controllerIntegration.GetResultAsync<UserAvatarResult>($"/api/AvatarUsers?id={id}");
		}

		public UserAvatarResult GetUserAvatar(int id)
		{
			return _getterAvatar.GetAvatarResult(id);
		}
	}
}
