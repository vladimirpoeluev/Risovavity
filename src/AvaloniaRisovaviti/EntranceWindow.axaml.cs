using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Tmds.DBus.Protocol;

namespace AvaloniaRisovaviti;

public partial class EntranceWindow : Window
{
    public EntranceWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }

    private void Reg_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Content = new RegistrationPage();
    }
}