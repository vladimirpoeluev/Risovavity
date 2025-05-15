using Autofac;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaRisovaviti.ViewModel.Author;

namespace AvaloniaRisovaviti;

public partial class AuthorsInfoPage : UserControl
{
    public AuthorsInfoPage()
    {
        InitializeComponent();
        DataContext = App.Container.Resolve <AuthorsInfoViewModel>();
    }
}