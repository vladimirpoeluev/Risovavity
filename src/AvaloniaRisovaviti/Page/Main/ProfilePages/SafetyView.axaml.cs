using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaRisovaviti;

public partial class SafetyView : UserControl
{
    public SafetyView()
    {
        InitializeComponent();
    }

	private void NavSession_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        page.Content = App.Container.Resolve<SesstionListView>();
	}

    private void NavPasswordEdid_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        page.Content = new ProfilePasswordEdit();
    }

	private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        page.Content = new SettingAccessRecoveryView();
	}
}