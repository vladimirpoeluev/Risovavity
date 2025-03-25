using Autofac;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class LikedCanvasView : View
{
    public LikedCanvasView()
    {
        InitializeComponent();
        ViewModel = App.Container.Resolve<LikedCanvasViewModel>();
    }
}