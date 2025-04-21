using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
}