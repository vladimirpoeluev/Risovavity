using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Other;

namespace AvaloniaRisovaviti;

public partial class SettingsAppView : UserControl
{
    public SettingsAppView()
    {
        InitializeComponent();
        DataContext = new SettingsAppViewModel();
    }
}