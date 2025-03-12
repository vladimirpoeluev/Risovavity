using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class MyWorkView : UserControl
{
    public MyWorkView()
    {
        InitializeComponent();
        DataContext = new MyWorkViewModel();
    }
}