using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class MyCanvasesView : UserControl
{
    public MyCanvasesView()
    {
        InitializeComponent();
        var vm = App.Container.Resolve<MyCanvasViewModel>();

		DataContext = vm;

        vm.OnNavAddCanvas += Nav_AddCanvas;
    }

    public void Nav_AddCanvas()
    {
        Content = App.Container.Resolve<FormAddNewCanvas>();
    }
}