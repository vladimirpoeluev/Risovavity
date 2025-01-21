using Autofac;
using Avalonia.Controls;
using AvaloniaEdit.Utils;
using AvaloniaRisovaviti.ViewModel.Canvas;
using DomainModel.ResultsRequest.Canvas;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti;

public partial class EditCanvasView : UserControl
{
    private EditCanvasViewModel _viewModel;
    public EditCanvasView() { }
    public EditCanvasView(CanvasResult canvasResult)
    {
        InitializeComponent();
        _viewModel = App.Container.Resolve<EditCanvasViewModel>();
        _viewModel.EditCanvas.Subscribe(EditClick);
        _viewModel.CanvasResult = canvasResult;
        DataContext = _viewModel;
    }

    private async void EditClick(Task<CanvasResult> canvas)
    {
        await canvas;
        Content = new CanvasPage();
    }
}