using Autofac;
using Autofac.Core;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaRisovaviti.Services;
using AvaloniaRisovaviti.Services.Interface;
using AvaloniaRisovaviti.ViewModel.Canvas;
using AvaloniaRisovaviti.ViewModel.Main;
using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;
using DomainModel.Integration;
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Exceptions;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using System;
using System.Net;

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
            builder.Register(ñ =>
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

            builder.RegisterType<AdderVesionProject>().As<IAdderVersionProject>();
            builder.RegisterType<DefinitionerOfPermission>()
                .As<InteractiveApiRisovaviti.Interface.IDefinitionerOfPermission>();
            builder.RegisterType<AdderCanvasParseApi>().As<IAdderCanvas>();
            builder.RegisterType<EditerCanvas>().As<IEditerCanvas>();
            builder.RegisterType<EditMainVersionInCanvas>().As<IEditMainVerstionInCanvas>();
            builder.RegisterType<EditVersionProject>().As<IEditVersionProject>();
            builder.RegisterType<GetterCanvasParseApi>().As<IGetterCanvas>();
            builder.RegisterType<GetterVersionProject>().As<IGetterVersionProject>();
            builder.RegisterType<GetterVersionProjectByParent>().As<IGetterVersionByParentVersion>();
            builder.RegisterType<SearchCanvas>().As<ISearcherCanvas>();
            builder.RegisterType<ServiceLikesOfCanvas>().As<ILikesOfCanvasService>();
            builder.RegisterType<ServiceLikesOfVersionProject>().As<ILikesOfVersitonService>();
            builder.RegisterType<TwoFactorAuthService>().As<ITwoFactorAuthService>();

            builder.RegisterType<MyCanvasViewModel>();
            builder.RegisterType<MyVersionViewModel>();
            builder.RegisterType<GetterWorksByAuthorId>().As<IGetterWorkByAuthorId>();

            builder.RegisterType<GetterDraftProject>().As<IGetterDraftProject>();
            builder.RegisterType<AdderNewProject>().As<IAdderNewProject>();
            builder.RegisterType<GetterWorksByLikes>().As<IGetterWorksByLikes>();

            builder.RegisterType<EditCanvasViewModel>();
            builder.RegisterType<DraftesViewModel>();
            builder.RegisterType<FormAddNewCanvas>();
            builder.RegisterType<LikedCanvasViewModel>();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Assets.Resource.Culture = new System.Globalization.CultureInfo("ru-RU");
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new EntranceWindow();
            }

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is AuthorizeException)
                {
                    Authentication.AuthenticationUser.User = new NotAuthenticationUser();
                    new EntranceWindow().Show();
				}
            };

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