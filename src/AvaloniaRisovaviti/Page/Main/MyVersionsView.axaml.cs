using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaRisovaviti.ViewModel.Canvas;
using ReactiveUI;

namespace AvaloniaRisovaviti;

public partial class MyVersionsView : ReactiveUserControl<MyVersionViewModel>
{
    MyVersionViewModel _viewModel;
    public MyVersionsView()
    {
        InitializeComponent();
        _viewModel = App.Container.Resolve<MyVersionViewModel>();

		this.DataContext = _viewModel;
		
	}

	private void UserControl_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		if (_viewModel != null) 
		{
			_viewModel.Init.Execute();
		}
	}
}