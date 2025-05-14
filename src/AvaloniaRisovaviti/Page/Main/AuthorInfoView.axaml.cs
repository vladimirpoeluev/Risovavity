using Autofac;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Author;

namespace AvaloniaRisovaviti;

public partial class AuthorInfoView : View
{
    public AuthorInfoView()
    {
        InitializeComponent();
        ViewModel = App.Container.Resolve<AuthorInfoViewModel>();
    }
}