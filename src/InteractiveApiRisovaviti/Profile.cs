using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration.ProfileController;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Profile : IPasswordEditer
	{
		public IAuthenticationUser User { get; set; }
		private IGetProfileControllerIntegration _getProfile;
		private ISetProfileControllerIntegration _setProfile;
		private ISetImageControllerIntegration _setImage;
		private IGetImageControllerIntegration _getImage;
		private IEditerPasswordControllerIntegration _editerPassword;


		public Profile(IAuthenticationUser user)
		{
			User = user;
			_getProfile = new GetProfileControllerIntegration(User);
			_setProfile = new SetProfileContrillerIntegration(User);
			_setImage = new SetImageControllerIntegration(User);
			_getImage = new GetImageControllerIntegration(User);
			_editerPassword = new EditPasswordControllerIntegraion(User);
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

		public UserAvatarResult ProfileAvatar
		{
			get
			{
				try
				{
					return _getImage.GetUserAvatar();
				}
				catch (Exception)
				{
					return new UserAvatarResult();
				}
			}

			set
			{
				value.UserName = String.Empty;
				_setImage.SetImage(value);
			}
		}

		public void PasswordUpdate(string oldPassword, string newPassword)
		{
			_editerPassword.PasswordEdit(new EditPasswordResult()
			{
				OldPassword = oldPassword,
				NewPassword = newPassword
			});
		}
	}
}
