using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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