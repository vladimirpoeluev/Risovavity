using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveApiRisovaviti
{
	internal abstract class GetControllerIntegration : ControlerIntegration
	{
		protected GetControllerIntegration(IAuthenticationUser user) : base(user)
		{
		}

		protected override IApiRequest SettingApiRequest() => new ApiGet();
	}
}
