using Autofac;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti;

public partial class LikedVersionProjectView : View
{
    public LikedVersionProjectView()
    {
        InitializeComponent();
        ViewModel = App.Container.Resolve<LikedVersionsProjectViewModel>();
    }
}