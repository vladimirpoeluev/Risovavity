using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Canvas;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti;

public partial class CanvasInfoPage : UserControl
{
    CanvasInfoPageViewModel _viewModel;
    public CanvasInfoPage()
    {
        InitializeComponent();
        _viewModel = new CanvasInfoPageViewModel();
        DataContext = _viewModel;
    }

    public CanvasInfoPage(CanvasResult canvas) : this()
    {
		_viewModel = new CanvasInfoPageViewModel(canvas);
	}

	private void ButtonAddVersion_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Content = new FormAddVersionPage(_viewModel.VersionProject);
	}
}