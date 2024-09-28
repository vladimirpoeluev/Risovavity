using DomainModel.Model;
using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class CartOfImage : UserControl
{
    public CartOfImage(InteractiveCanvas incanvas)
    {
        InitializeComponent();
        DataContext = new CartOfImageViewModel(incanvas);
    }
}