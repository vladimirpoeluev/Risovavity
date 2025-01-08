using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Main;

namespace AvaloniaRisovaviti;

public partial class ConfimationUserView : UserControl
{
    public ConfimationUserViewModel ViewModel { get; set; }
    public ConfimationUserView(ConfimationUserViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = viewModel;
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