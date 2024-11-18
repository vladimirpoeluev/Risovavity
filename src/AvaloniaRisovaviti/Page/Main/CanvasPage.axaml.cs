using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class CanvasPage : UserControl
{
    public CanvasPage()
    {
        InitializeComponent();
        DataContext = new CanvasPageViewModel();
    }

    public void NavAddCanvas_Click(object obj, RoutedEventArgs args)
    {
        Content = new FormAddNewCanvas();
    }
}