using Avalonia;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class CanvasPage : UserControl
{
    public CanvasPage()
    {
        InitializeComponent();
        DataContext = new CanvasPageViewModel();
    }
}