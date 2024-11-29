using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel.Canvas;
using MsBox.Avalonia;
using System;

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

	private async void ListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
        try
        {
            
		}
        catch(Exception ex)
        {
            await MessageBoxManager.GetMessageBoxStandard("Ошибка", ex.Message, icon: MsBox.Avalonia.Enums.Icon.Error).ShowAsync();
        }
	}
}
