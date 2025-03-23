using Autofac;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class DraftesView : View
{
    public DraftesView()
    {
        InitializeComponent();
        ViewModel = App.Container.Resolve<DraftesViewModel>();
    }
}