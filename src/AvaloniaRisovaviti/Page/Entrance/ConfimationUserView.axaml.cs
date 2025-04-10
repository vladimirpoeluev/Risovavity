using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Main;

namespace AvaloniaRisovaviti;

public partial class ConfimationUserView : View
{
    public ConfimationUserViewModel ViewModel { get; set; }
    public ConfimationUserView(ConfimationUserViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        base.ViewModel = viewModel;
    }

	private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        try
        {
			Authentication.AuthenticationUser.User = await ViewModel.UserConfirmaiton();
			Content = new MainPage();
		}
        catch
        {
            Content = App.Container.Resolve<EntrancePage>();
        }
        

	}
}