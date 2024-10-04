using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class AuthenticationUser : IAuthenticationUser
	{
		private string Token { get; set; }
		public AuthenticationUser(string token) 
		{
			Token = token;
		}

		public void SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
		}
	}
}
