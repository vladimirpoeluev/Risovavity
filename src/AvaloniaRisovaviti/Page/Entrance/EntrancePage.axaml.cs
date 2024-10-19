using Avalonia.Interactivity;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel;
using InteractiveApiRisovaviti;
using System;

namespace AvaloniaRisovaviti;

public partial class EntrancePage : UserControl
{
    EntrancePageViewModel viewModel;
    public EntrancePage()
    {
        InitializeComponent();
        viewModel = new EntrancePageViewModel();
        DataContext = viewModel;
    }

    private void Button_Click(object? obj, RoutedEventArgs e)
    {
        try
        {
			Entrance entrance = new Entrance();
			Authentication.AuthenticationUser.User = entrance.IputSystem(viewModel.Login, viewModel.Password);
			this.Content = new MainPage();
		}
        catch(Exception)
        {
            viewModel.Error = "Логин или пароль были введены неверно";
        }        
    }

    private void Reg_Click(object? sender, RoutedEventArgs e)
    {
        this.Content = new RegistrationPage();
    }
}