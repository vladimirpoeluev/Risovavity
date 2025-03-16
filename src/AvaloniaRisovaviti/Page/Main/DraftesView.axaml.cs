using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class DraftesView : UserControl
{
    public DraftesView()
    {
        InitializeComponent();
        DataContext = App.Container.Resolve<DraftesViewModel>();
    }
}