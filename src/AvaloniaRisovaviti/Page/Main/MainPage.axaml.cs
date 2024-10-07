using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaRisovaviti;

public partial class MainPage : UserControl
{
    public MainPage()
    {
        InitializeComponent();
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
}