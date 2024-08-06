using AvaloniaRisovaviti.ViewModel;
using Avalonia.Controls;
using DomainModel.Records;

namespace AvaloniaRisovaviti;

public partial class CartOfAuthor : UserControl
{
    public CartOfAuthor(User user)
    {
        InitializeComponent();
        DataContext = new CartOfAuthorViewModel(user);
    }
}