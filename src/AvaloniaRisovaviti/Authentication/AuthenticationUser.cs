using Autofac;
using AvaloniaRisovaviti.Cript;
using AvaloniaRisovaviti.Cript.Interfaces;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Authentication
{
	internal static class AuthenticationUser
	{
		static IAuthenticationUser _user;

		public static IEncryptionSession Session { get; set; } 
			= new EncryptionSession(new EncryptionCreater());
		
		public static IAuthenticationUser User 
		{
			get 
			{
				return _user; 
			} 
			set 
			{
				_user = value;
				Session.SetSessionAsync(value);
			} 
		} 

		public static async Task ExitSystem()
		{
			var sessionService = App.Container.Resolve<ISessionService>();
			await sessionService.DeleteSesstionAsync();

			User = InteractiveApiRisovaviti
			.HttpIntegration
			.AuthenticationUser.NotAuthenticationUser;
		}

		static AuthenticationUser()
		{
			if (Session.TryGetSession(out IAuthenticationUser user))
				_user = user;
			else			
				_user = InteractiveApiRisovaviti.HttpIntegration.AuthenticationUser.NotAuthenticationUser;
		}
	}
}
