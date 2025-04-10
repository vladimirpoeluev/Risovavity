using Autofac;
using Avalonia.ReactiveUI;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class MyVersionsView : View
{
    MyVersionViewModel _viewModel;
    public MyVersionsView()
    {
        InitializeComponent();
        _viewModel = App.Container.Resolve<MyVersionViewModel>();

		ViewModel = _viewModel;
		
	}

	private void UserControl_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		if (_viewModel != null) 
		{
			_viewModel.Init.Execute();
		}
	}
}