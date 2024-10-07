using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Profile
	{
		public IAuthenticationUser User { get; set; }

		public Profile(IAuthenticationUser user)
		{
			User = user;
		}

		public UserResult ProfileUser 
		{ 
			get
			{
				IGetProfileControllerIntegration getProfile = new GetProfileControllerIntegration(User);
				return getProfile.GetProfile();
			} 
		}
	}
}
