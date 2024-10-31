using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class ProfilePasswordEdit : UserControl
{
    ProfilePasswordEditViewModel _viewModel;
    public ProfilePasswordEdit()
    {
        InitializeComponent();
        _viewModel = new ProfilePasswordEditViewModel();
        DataContext = _viewModel;
    }

    public void PasswordEdit_Click(object obj, RoutedEventArgs args)
    {
        _viewModel.PasswordEdit();
    }


}