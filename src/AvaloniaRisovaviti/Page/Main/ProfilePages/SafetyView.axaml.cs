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
}