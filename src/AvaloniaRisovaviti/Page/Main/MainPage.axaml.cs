using Autofac;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel.Main;
using InteractiveApiRisovaviti.Interface;

namespace AvaloniaRisovaviti;

public partial class MainPage : UserControl
{
    MainPageViewModel viewModel;
    public MainPage()
    {
        InitializeComponent();
        viewModel = new MainPageViewModel();
        DataContext = viewModel; 
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
       frameMain.Content = new InteractiveCanvasPage();
    }
    public void Canvas_Click(object ob, RoutedEventArgs e)
    {
       frameMain.Content = new CanvasPage();
    }

    public void Profile_Click(object ob, RoutedEventArgs e) 
    {
        frameMain.Content = new ProfileEditerPage();
    }

    public async void ExitProfile_Click(object ob, RoutedEventArgs e) 
    {
        await Authentication.AuthenticationUser.ExitSystem();
        this.Content = App.Container.Resolve<EntrancePage>();
    }

    public void UpdateData_Click(object ob, RoutedEventArgs e)
    {
        viewModel.InitUser();
    }
}