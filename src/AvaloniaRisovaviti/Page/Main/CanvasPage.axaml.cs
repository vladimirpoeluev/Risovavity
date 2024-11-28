using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;
using DomainModel.ResultsRequest.Canvas;
using MsBox.Avalonia;
using System.Linq;

namespace AvaloniaRisovaviti;

public partial class CanvasPage : UserControl
{
    CanvasPageViewModel _viewModel;
    public CanvasPage()
    {
        InitializeComponent();
        _viewModel = new CanvasPageViewModel();
        DataContext = _viewModel;
    }

    public void NavAddCanvas_Click(object obj, RoutedEventArgs args)
    {
        Content = new FormAddNewCanvas();
    }

	private void ListBox_ContainerIndexChanged(object? sender, Avalonia.Controls.ContainerIndexChangedEventArgs e)
    {
		
	}

	private async void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
	{
		Content = new CanvasInfoPage(_viewModel.SelectedCanvas.CanvasResult);
	}
}
