using Autofac;
using Avalonia.Controls;

namespace AvaloniaRisovaviti;

public partial class EntranceWindow : Window
{
    public EntranceWindow()
    {
        InitializeComponent();
        window.Content = App.Container.Resolve<EntrancePage>();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }

    private void Reg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
		window.Content = new RegistrationPage();
    }
}