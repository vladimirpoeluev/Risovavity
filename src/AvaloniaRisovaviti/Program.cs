using Avalonia;
using Avalonia.ReactiveUI;
using InteractiveApiRisovaviti.HttpIntegration;
using System;

namespace AvaloniaRisovaviti
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) 
        {
            try
            {
				BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
			}
            catch(Exception ex)
            {
                Authentication.AuthenticationUser.User = new NotAuthenticationUser();
                Main(args);
            }
            
			
		} 

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI();
    }
}
