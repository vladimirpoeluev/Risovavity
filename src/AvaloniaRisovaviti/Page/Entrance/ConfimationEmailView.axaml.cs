using Autofac;
using Avalonia.Controls;
using AvaloniaEdit.Utils;
using AvaloniaRisovaviti.ViewModel.Main;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti;

public partial class ConfimationEmailView : UserControl
{
    public ConfimationEmailViewModel ViewModel { get; set; }
    public ConfimationEmailView() { }
    public ConfimationEmailView(ConfimationEmailViewModel viewModel)
    {
        InitializeComponent();
        viewModel.NavEntrance.Subscribe(NavEntranceView);
        ViewModel = viewModel;
        DataContext = ViewModel;
    }

    private async void NavEntranceView(Task<EntrancePageViewModel> viewModel)
    {
        EntrancePageViewModel vm = await viewModel;
        Content = App.Container.Resolve<EntrancePage>();
    }
}