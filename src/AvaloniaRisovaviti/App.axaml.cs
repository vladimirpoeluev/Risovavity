using Autofac;
using Autofac.Core;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services;
using AvaloniaRisovaviti.Services.Interface;
using AvaloniaRisovaviti.ViewModel.Author;
using AvaloniaRisovaviti.ViewModel.Canvas;
using AvaloniaRisovaviti.ViewModel.Main;
using AvaloniaRisovaviti.ViewModel.Other;
using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;
using DomainModel.Integration;
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Exceptions;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Interface.Topt;
using InteractiveApiRisovaviti.TotpOperate;
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
            builder.RegisterType<LikedVersionsProjectViewModel>();
            builder.RegisterType<SettingsAppService>().As<ISettingsAppService>();
            builder.RegisterType<SettingsAppViewModel>();
            builder.RegisterType<GetterTotpKey>().As<IGetterTotp>();
            builder.RegisterType<AccessRecovery>().As<IAccessRecovery>();
            builder.RegisterType<SettingAccessRecoveryViewModel>();
            builder.RegisterType<RestoreAccessViewModel>();
            builder.RegisterType<AuthorInfoViewModel>();
            builder.RegisterType<AuthorsInfoViewModel>();
            builder.RegisterType<AuthorViewModel>();

            builder.RegisterType<AvatarGetter>().As<IUserAvatarGetter>();
            builder.RegisterType<AuthorGetter>().As<IAuthorGetter>();
            builder.RegisterType<GetterImageProject>().As<IGetterImageProject>();
        }

        public override async void OnFrameworkInitializationCompleted()
        {
           
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new EntranceWindow();
            }

			var settingsService = Container.Resolve<ISettingsAppService>();
			SettingsApp settings = await settingsService.GetSettings();

			Assets.Resource.Culture = new System.Globalization.CultureInfo(settings.Lang);
			this.RequestedThemeVariant = settings.Theme == "Light" ? ThemeVariant.Light : ThemeVariant.Dark;

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