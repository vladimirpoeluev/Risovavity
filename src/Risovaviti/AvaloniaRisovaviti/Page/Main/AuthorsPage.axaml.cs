using Avalonia;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class AuthorsPage : UserControl
{
    public AuthorsPage()
    {
        InitializeComponent();
        DataContext = new AuthorViewModel();
    }
}