using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration.ProfileController;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Profile
	{
		public IAuthenticationUser User { get; set; }
		IGetProfileControllerIntegration _getProfile;
		ISetProfileControllerIntegration _setProfile;

		public Profile(IAuthenticationUser user)
		{
			User = user;
			_getProfile = new GetProfileControllerIntegration(User);
			_setProfile = new SetProfileContrillerIntegration(User);
		}

		public UserResult ProfileUser 
		{ 
			get
			{
				return _getProfile.GetProfile();
			}
			
			set
			{
				_setProfile.SetProfile(value);
			}
		}

	}
}
