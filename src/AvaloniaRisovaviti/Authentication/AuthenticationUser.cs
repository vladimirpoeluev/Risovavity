using InteractiveApiRisovaviti.Interface;

namespace AvaloniaRisovaviti.Authentication
{
	internal static class AuthenticationUser
	{
		public static IAuthenticationUser User { get; set; } = InteractiveApiRisovaviti
			.HttpIntegration
			.AuthenticationUser.NotAuthenticationUser;

	}
}
