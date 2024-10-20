using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration.AvatarUsers;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class AvatarGetter
	{
		IAvatarUsersControllerIntegration _getterAvatar;

		public AvatarGetter(IAuthenticationUser user)
		{
			_getterAvatar = new AvatarUsersControllerIntegration(user);
		}

		public UserAvatarResult GetUserAvatar(int id)
		{
			return _getterAvatar.GetAvatarResult(id);
		}
	}
}
