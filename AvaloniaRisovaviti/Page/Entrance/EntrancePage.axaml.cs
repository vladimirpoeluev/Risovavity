using Avalonia.Interactivity;
using Avalonia.Controls;

namespace AvaloniaRisovaviti;

public partial class EntrancePage : UserControl
{
    public EntrancePage()
    {
        InitializeComponent();
    }

    private void Button_Click(object? obj, RoutedEventArgs e)
    {
        this.Content = new MainPage();
        
    }

    private void Reg_Click(object? sender, RoutedEventArgs e)
    {
        this.Content = new RegistrationPage();
    }
}