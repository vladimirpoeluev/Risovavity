using Azure.Identity;
using DomainModel.ResultsRequest;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EmailIntegration
{
	public class UserConfirmation
	{
		public IEntranceUser _entrancerUser;

		public UserConfirmation(IEntranceUser entranceUser)
		{
			_entrancerUser = entranceUser;
		}

		public async Task AddToPendingConfirmation(AuthenticationForm form)
		{
			await _entrancerUser.Login(form);
		}
	}
}
