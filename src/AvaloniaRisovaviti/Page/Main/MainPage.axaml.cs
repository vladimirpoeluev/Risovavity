using Autofac;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Main;
using MsBox.Avalonia;

namespace AvaloniaRisovaviti;

public partial class MainPage : View
{
    MainPageViewModel viewModel;
    public MainPage()
    {
        InitializeComponent();
        try
        {
			viewModel = new MainPageViewModel();
			ViewModel = viewModel;
		}
        catch
        {

        }
       
    }

    public void MyCanvas_Click(object ob, RoutedEventArgs e)
    {
        frameMain.Content = new MyCanvasPage();
    }
    public void Authors_Click(object ob, RoutedEventArgs e)
    {
       frameMain.Content = new AuthorsPage();
    }
    public void InteractiveCanvas_Click(object ob, RoutedEventArgs e)
    {
       frameMain.Content = new LikedWorksView();
    }
    public void Canvas_Click(object ob, RoutedEventArgs e)
    {
       frameMain.Content = new MyWorkView();
    }

    public void Profile_Click(object ob, RoutedEventArgs e) 
    {
        frameMain.Content = new ProfileEditerPage();
    }

    public async void ExitProfile_Click(object ob, RoutedEventArgs e) 
    {
        try
        {
			await Authentication.AuthenticationUser.ExitSystem();
		}
        catch 
        {
            MessageBoxManager.GetMessageBoxStandard("Ошибка!!!", "Выход из системы вызвал ошибку");
        }
        Content = App.Container.Resolve<EntrancePage>();
    }

    public void UpdateData_Click(object ob, RoutedEventArgs e)
    {
        viewModel.InitUser();
    }
}