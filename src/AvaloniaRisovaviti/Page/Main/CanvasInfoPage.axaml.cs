using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti;

public partial class CanvasInfoPage : UserControl
{
    
    public CanvasInfoPage()
    {
        InitializeComponent();
    }

    public CanvasInfoPage(CanvasResult canvas) : base()
    {

    }

	private void ButtonAddVersion_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        Content = new FormAddVersionPage();
	}
}