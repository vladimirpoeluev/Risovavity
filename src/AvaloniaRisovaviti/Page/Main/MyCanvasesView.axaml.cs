using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class MyCanvasesView : UserControl
{
    public MyCanvasesView()
    {
        InitializeComponent();
        DataContext = App.Container.Resolve<MyCanvasViewModel>();
    }
}