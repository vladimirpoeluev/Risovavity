using Avalonia.ReactiveUI;
using AvaloniaRisovaviti.ViewModel.Canvas;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti;

internal partial class FormAddVersionPage : ReactiveUserControl<FormAddVersionViewModel>
{
    private FormAddVersionViewModel _viewModel;

    public FormAddVersionPage()
    {
        InitializeComponent();
        _viewModel = new FormAddVersionViewModel();
        DataContext = _viewModel;
    }

    public FormAddVersionPage(VersionProjectResult version) : this()
    {
        _viewModel = new FormAddVersionViewModel(version);
        DataContext = _viewModel;
    }

	private void AddVersionClick_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
        
	}
}