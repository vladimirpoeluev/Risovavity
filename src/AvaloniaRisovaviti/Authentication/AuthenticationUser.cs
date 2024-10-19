using InteractiveApiRisovaviti.Interface;

namespace AvaloniaRisovaviti.Authentication
{
	internal static class AuthenticationUser
	{
		public static IAuthenticationUser User { get; set; } = InteractiveApiRisovaviti
			.HttpIntegration
			.AuthenticationUser.NotAuthenticationUser;

		public static void ExitSystem()
		{
			User = InteractiveApiRisovaviti
			.HttpIntegration
			.AuthenticationUser.NotAuthenticationUser;
		}
	}
}
