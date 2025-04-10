using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Author;

namespace AvaloniaRisovaviti;

public partial class AuthorsPage : View
{
    AuthorViewModel AuthorViewModel { get; set; }
    public AuthorsPage()
    {
        InitializeComponent();
		AuthorViewModel = new AuthorViewModel();
		ViewModel = AuthorViewModel;
    }

    public void AddAuthorShow_Click(object obj, RoutedEventArgs args)
    {
    }

	private void Binding(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
	}
}