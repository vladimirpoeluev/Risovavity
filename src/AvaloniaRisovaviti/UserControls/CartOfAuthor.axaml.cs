using AvaloniaRisovaviti.ViewModel;
using Avalonia.Controls;
using DomainModel.Model;
using AvaloniaRisovaviti.ViewModel.Other;

namespace AvaloniaRisovaviti;

public partial class CartOfAuthor : UserControl
{
    public CartOfAuthor(User user)
    {
        InitializeComponent();
        DataContext = new CartOfAuthorViewModel(user);
    }
}