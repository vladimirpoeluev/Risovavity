using Avalonia.Controls;
using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;

namespace AvaloniaRisovaviti;

public partial class SesstionListView : UserControl
{
    public SesstionListView(SessionListViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}