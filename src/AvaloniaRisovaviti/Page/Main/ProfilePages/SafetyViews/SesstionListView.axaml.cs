using Avalonia.Controls;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;

namespace AvaloniaRisovaviti;

public partial class SesstionListView : View
{
    public SesstionListView(SessionListViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
    }
}