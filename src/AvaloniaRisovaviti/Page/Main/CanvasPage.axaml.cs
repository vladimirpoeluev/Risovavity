using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;
using MsBox.Avalonia;

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

	private void ListBox_ContainerIndexChanged(object? sender, ContainerIndexChangedEventArgs e)
    {
		
	}

	private void ListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
        try
        {
			Content = new CanvasInfoPage(_viewModel.SelectedCanvas.CanvasResult);
		}
        catch{}
	}

	private void Button_Click(object? sender, RoutedEventArgs e)
	{
		
	}
}
