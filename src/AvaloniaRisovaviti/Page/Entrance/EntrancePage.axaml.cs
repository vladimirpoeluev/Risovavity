using Avalonia.Interactivity;
using Avalonia.Controls;
using InteractiveApiRisovaviti;
using System;
using AvaloniaRisovaviti.ViewModel.Main;
using System.Net.Http;
using InteractiveApiRisovaviti.HttpIntegration;

namespace AvaloniaRisovaviti;

public partial class EntrancePage : UserControl
{
    EntrancePageViewModel viewModel;
    public EntrancePage()
    {
        InitializeComponent();
        if(Authentication.AuthenticationUser.User != AuthenticationUser.NotAuthenticationUser)
        {
            Content = new MainPage();
        }
        viewModel = new EntrancePageViewModel();
        DataContext = viewModel;
    }

    private void Button_Click(object? obj, RoutedEventArgs e)
    {
        var user = Authentication.AuthenticationUser.User;
        if(Authentication.AuthenticationUser.User != AuthenticationUser.NotAuthenticationUser)
        {
			this.Content = new MainPage();
            return;
		}
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