
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	internal abstract class ControlerIntegration
	{
		private IAuthenticationUser User { get; set; }
		
		public ControlerIntegration(IAuthenticationUser user)
		{
			User = user;
		}

		private void OptionAuthentication(HttpClient client) 
		{
			User.SettingUpDataProvisioning(client);
		}

		public abstract HttpRequestMessage StartRequest(IApiRequest client);
	}
}
