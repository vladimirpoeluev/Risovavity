using Avalonia.Controls;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti;

public partial class FormAddVersionPage : UserControl
{
    public FormAddVersionPage()
    {
        InitializeComponent();
    }

    public FormAddVersionPage(VersionProjectResult version) : base()
    {

    }

	private void AddVersionClick_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        
	}
}