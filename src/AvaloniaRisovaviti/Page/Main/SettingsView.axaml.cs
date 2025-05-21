using Autofac;
using Avalonia.Controls;
using System.Configuration;
using System.Diagnostics;

namespace AvaloniaRisovaviti;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

	private void NavSafety_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Content = App.Container.Resolve<SafetyView>();
	}
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Content = new SettingsAppView();
    }

	private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Content = new ProfileEditerPage();
	}

	private void Button_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Process.Start(new ProcessStartInfo(ConfigurationManager.AppSettings["Address"] + "/privacy.html")
        {
            UseShellExecute = true,
        });
	}
}      