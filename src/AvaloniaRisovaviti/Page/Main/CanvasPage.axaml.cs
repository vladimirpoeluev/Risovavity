using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;
using DomainModel.ResultsRequest.Canvas;
using MsBox.Avalonia;
using System;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti;

public partial class CanvasPage : View
{
    CanvasPageViewModel _viewModel;
    public CanvasPage()
    {
        InitializeComponent();
        TryInitViewModel();
    }

    void TryInitViewModel()
    {
        try
        {
            _viewModel = new CanvasPageViewModel();
            _viewModel.OnClickUpdateItem += ClickUpdateEvent;
            ViewModel = _viewModel;
        }
        catch { }
	}
    private async void ClickUpdateEvent(Task<CanvasResult> result)
    {
        Content = new EditCanvasView(await result);
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
