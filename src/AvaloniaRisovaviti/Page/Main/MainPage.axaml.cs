using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

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

    public void ExitProfile_Click(object ob, RoutedEventArgs e) 
    {
        this.Content = new EntrancePage();
        Authentication.AuthenticationUser.ExitSystem();
    }
}