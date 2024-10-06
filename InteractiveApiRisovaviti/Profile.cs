using DomainModel.Model;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
