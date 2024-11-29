using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel.Profile;

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
        if (_viewModel.State == StateEditPassword.Ok)
            Content = new ProfileEditerPage();
    }


}