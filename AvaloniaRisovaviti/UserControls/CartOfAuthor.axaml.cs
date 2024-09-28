using AvaloniaRisovaviti.ViewModel;
using Avalonia.Controls;
using DomainModel.Model;

namespace AvaloniaRisovaviti;

public partial class CartOfAuthor : UserControl
{
    public CartOfAuthor(User user)
    {
        InitializeComponent();
        DataContext = new CartOfAuthorViewModel(user);
    }
}