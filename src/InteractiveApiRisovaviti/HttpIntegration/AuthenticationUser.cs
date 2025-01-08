using InteractiveApiRisovaviti.Interface;
using System.Runtime.InteropServices;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class AuthenticationUser : IAuthenticationUser
	{
		public static IAuthenticationUser NotAuthenticationUser { get; } = new NotAuthenticationUser();
		private string Token { get; set; }
		protected virtual string NameOfApp { get; set; } = $"AvaloniaAppNon";
		protected virtual string VersionOfApp { get; set; } = $"0.3.3";
		public AuthenticationUser(string token) 
		{
			Token = token;
		}

		public void SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgentGenerator.GetUserAgent(NameOfApp, VersionOfApp));
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
		}

		static string GetOSInfo()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return $"Windows NT 10.0; {RuntimeInformation.RuntimeIdentifier}; {RuntimeInformation.OSArchitecture}";
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				return $"Mac OS X 10_15_7; {RuntimeInformation.RuntimeIdentifier}; {RuntimeInformation.OSArchitecture}";
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				return $"Windows NT 10.0; {RuntimeInformation.RuntimeIdentifier}; {RuntimeInformation.OSArchitecture}";
			}
			
			return $"";
		}
	}
}
