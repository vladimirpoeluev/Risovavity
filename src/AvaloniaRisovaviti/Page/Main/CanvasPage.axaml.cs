using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

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

	private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
	{
		
	}

	private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		Content = new CanvasInfoPage(_viewModel.SelectedCanvas.CanvasResult);
	}
}
