using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class AuthenticationUser : IAuthenticationUser
	{
		public static AuthenticationUser NotAuthenticationUser { get; } = new AuthenticationUser(String.Empty); 
		private string Token { get; set; }
		public AuthenticationUser(string token) 
		{
			Token = token;
		}

		public void SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
		}
	}
}
