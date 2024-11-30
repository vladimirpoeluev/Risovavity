using Avalonia.Controls;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti;

public partial class FormAddVersionPage : UserControl
{
    public FormAddVersionPage()
    {
        InitializeComponent();
    }

    public FormAddVersionPage(VersionProjectResult version) : this()
    {
        
    }

	private void AddVersionClick_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        
	}
}