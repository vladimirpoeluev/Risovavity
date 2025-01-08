using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class NotAuthenticationUser : IAuthenticationUser
	{
		protected virtual string NameOfApp { get; set; } = $"AvaloniaAppNon";
		protected virtual string VersionOfApp { get; set; } = $"0.3.3";

		public void SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgentGenerator.GetUserAgent(NameOfApp, VersionOfApp));
		}
	}
}
