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

		protected abstract IApiRequest SettingApiRequest();

		protected abstract HttpResponseMessage StartRequest(IApiRequest client);

		protected HttpResponseMessage GetResponseMessage()
		{
			return StartRequest(SettingApiRequest());
		}
	}
}
