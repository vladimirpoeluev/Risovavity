using Autofac;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Other;

namespace AvaloniaRisovaviti;

public partial class RestoreAccessView : View
{
    public RestoreAccessView()
    {
        InitializeComponent();
        var viewModel = App.Container.Resolve<RestoreAccessViewModel>();
        viewModel.Back = () =>
        {
            Content = App.Container.Resolve<EntrancePage>();
        };
		ViewModel = viewModel;
    }
}