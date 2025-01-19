using Autofac;
using Autofac.Core;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaRisovaviti.ViewModel.Main;
using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Exceptions;
using InteractiveApiRisovaviti.Interface;
using System;

namespace AvaloniaRisovaviti
{
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }

        public override void Initialize()
        {
            var builder = new ContainerBuilder();
            ConfiguredContaner(builder);
            Container = builder.Build();
            

            AvaloniaXamlLoader.Load(this);
        }

        void ConfiguredContaner(ContainerBuilder builder)
        {
            builder.RegisterType<CreaterAuthoControllersIntegraion>()
                .As<FabricAutoControllerIntegraion>();
            builder.RegisterType<EntranceRefresh>().As<IEntrance>();
            builder.RegisterType<EntrancePageViewModel>();
            builder.RegisterType<EntrancePage>();
            builder.RegisterType<SettingsView>();
			builder.RegisterType<SesstionService>().As<ISessionService>();
            builder.Register(� =>
            {
                return Authentication.AuthenticationUser.User;
            }).As<IAuthenticationUser>();

			builder.RegisterType<SesstionListView>();
            builder.RegisterType<SessionListViewModel>();
            builder.RegisterType<SafetyView>();
            builder.RegisterType<ConfimationUserView>();
            builder.RegisterType<ConfimationUserViewModel>();
            builder.RegisterType<ConfirmationViaEmail>().As<IConfirmationViaEmail>();
            builder.RegisterType<ConfimationEmailViewModel>();
            builder.RegisterType<ConfimationEmailView>();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Assets.Resource.Culture = new System.Globalization.CultureInfo("ru-RU");
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new EntranceWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        void TryException(Exception ex)
        {
            if(ex is AuthorizeException)
            {
                OnFrameworkInitializationCompleted();
            }
        }

    }
}