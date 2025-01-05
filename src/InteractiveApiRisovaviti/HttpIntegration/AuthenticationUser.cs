using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class AuthenticationUser : IAuthenticationUser
	{
		public static AuthenticationUser NotAuthenticationUser { get; } = new AuthenticationUser(String.Empty); 
		private string Token { get; set; }
		protected virtual string NameOfApp { get; set; } = "AvaloniaAppNon";
		protected virtual string VersionOfApp { get; set; } = "0.3.3";
		public AuthenticationUser(string token) 
		{
			Token = token;
		}

		public void SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(NameOfApp, VersionOfApp));
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
		}
	}
}
