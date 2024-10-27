using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class AuthorsPage : UserControl
{
    AuthorViewModel AuthorViewModel { get; set; }
    public AuthorsPage()
    {
        InitializeComponent();
		AuthorViewModel = new AuthorViewModel();
		DataContext = AuthorViewModel;
    }

    public void AddAuthorShow_Click(object obj, RoutedEventArgs args)
    {
        AuthorViewModel.ContinueListAuthors();
    }
}