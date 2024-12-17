using InteractiveApiRisovaviti.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class AuthenticationUserByRefresh : IAuthenticationUserByRefresh, IAuthenticationUserForSave
	{
		Stream IAuthenticationUserForSave.Stream => throw new NotImplementedException();

		void IAuthenticationUser.SettingUpDataProvisioning(HttpClient client)
		{
			throw new NotImplementedException();
		}

		Task IAuthenticationUserByRefresh.TryUpdateToken(ref bool isValid)
		{
			throw new NotImplementedException();
		}
	}
}
