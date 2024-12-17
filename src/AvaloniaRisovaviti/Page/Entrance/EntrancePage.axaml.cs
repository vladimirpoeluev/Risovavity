using Avalonia.Interactivity;
using Avalonia.Controls;
using InteractiveApiRisovaviti;
using System;
using AvaloniaRisovaviti.ViewModel.Main;
using System.Net.Http;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;

namespace AvaloniaRisovaviti;

public partial class EntrancePage : UserControl
{
    EntrancePageViewModel viewModel;
    IEntrance entrance;

	public EntrancePage(EntrancePageViewModel viewModel, IEntrance entrance)
    {
        InitializeComponent();
        try
        {
			if (Authentication.AuthenticationUser.User != AuthenticationUser.NotAuthenticationUser)
			{
				Content = new MainPage();
			}
		}
        catch{}
        
        this.viewModel = viewModel;
        this.entrance = entrance;
        DataContext = viewModel;
    }

    private void Button_Click(object? obj, RoutedEventArgs e)
    {
        try
        {
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