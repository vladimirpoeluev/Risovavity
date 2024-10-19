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
			
		}
        catch(Exception ex)
        {
            viewModel.Error = ex.Message;
        }
        finally
        {
			this.Content = new MainPage();
		}        
    }

    private void Reg_Click(object? sender, RoutedEventArgs e)
    {
        this.Content = new RegistrationPage();
    }
}