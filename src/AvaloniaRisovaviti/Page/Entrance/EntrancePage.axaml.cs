using Avalonia.Interactivity;
using Avalonia.Controls;
using InteractiveApiRisovaviti;
using System;
using AvaloniaRisovaviti.ViewModel.Main;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using Autofac;
using AvaloniaRisovaviti.Assets;

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
            if(!(Authentication.AuthenticationUser.User is NotAuthenticationUser))
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
            if(Authentication.AuthenticationUser.User == AuthenticationUser.NotAuthenticationUser)
            {
                var view = App.Container.Resolve<ConfimationUserView>();
                view.ViewModel.Code.Login = viewModel.Login;
                Content = view;
                return;
            }
			this.Content = new MainPage();
		}
        catch(Exception)
        {
            viewModel.Error = Resource.enteredIncorrectly;
        }        
    }

    private void Reg_Click(object? sender, RoutedEventArgs e)
    {
        this.Content = new RegistrationPage();
    }

	private void Button_Click1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        this.Content = new RestoreAccessView();
	}
}