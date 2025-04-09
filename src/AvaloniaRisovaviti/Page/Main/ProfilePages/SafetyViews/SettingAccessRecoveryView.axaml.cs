using Autofac;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Other;

namespace AvaloniaRisovaviti;

public partial class SettingAccessRecoveryView : View
{
    public SettingAccessRecoveryView()
    {
        InitializeComponent();
        ViewModel = App.Container.Resolve<SettingAccessRecoveryViewModel>();
    }
}