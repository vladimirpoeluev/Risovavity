using Avalonia.Controls;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti;

public partial class CanvasInfoPage : View
{
    CanvasInfoPageViewModel _viewModel;
    public CanvasInfoPage()
    {
        InitializeComponent();
        _viewModel = new CanvasInfoPageViewModel();
        ViewModel = _viewModel;
    }

    public CanvasInfoPage(CanvasResult canvas) : this()
    {
		_viewModel = new CanvasInfoPageViewModel(canvas);
		DataContext = _viewModel;
	}

	private void ButtonAddVersion_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Content = new FormAddVersionPage(_viewModel.VersionProject);
	}

	private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
	}
}