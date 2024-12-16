using Autofac;
using Autofac.Core;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace AvaloniaRisovaviti
{
    public partial class App : Application
    {
        public IContainer Container { get; private set; }
        public override void Initialize()
        {
			var builder = new ContainerBuilder();
			ConfiguredContaner(builder);
            Container = builder.Build();

            AvaloniaXamlLoader.Load(this);
        }

        void ConfiguredContaner(ContainerBuilder builder)
        {
            builder.RegisterType<FabricAutoControllerIntegraion>()
                .As<CreaterAuthoControllersIntegraion>();
            builder.RegisterType<IEntrance>().As<Entrance>();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new EntranceWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}