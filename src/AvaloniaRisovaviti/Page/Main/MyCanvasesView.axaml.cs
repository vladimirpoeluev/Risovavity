using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class MyCanvasesView : View
{
    public MyCanvasesView()
    {
        InitializeComponent();
        var vm = App.Container.Resolve<MyCanvasViewModel>();

		ViewModel = vm;

        vm.OnNavAddCanvas += Nav_AddCanvas;
    }

    public void Nav_AddCanvas()
    {
        Content = App.Container.Resolve<FormAddNewCanvas>();
    }
}