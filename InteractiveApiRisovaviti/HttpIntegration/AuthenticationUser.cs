using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class AuthenticationUser : IAuthenticationUser
	{
		public static AuthenticationUser NotAuthenticationUser { get; } = new AuthenticationUser(String.Empty); 
		private string Token { get; set; }
		public AuthenticationUser(string token) 
		{
			Token = token;
		}

		public void SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
		}

		public override string ToString() => $"{Token}";
	}
}
