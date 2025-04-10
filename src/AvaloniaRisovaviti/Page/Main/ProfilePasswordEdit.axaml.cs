using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;

namespace AvaloniaRisovaviti;

public partial class ProfilePasswordEdit : View
{
    ProfilePasswordEditViewModel _viewModel;
    public ProfilePasswordEdit()
    {
        InitializeComponent();
        _viewModel = new ProfilePasswordEditViewModel();
        ViewModel = _viewModel;
    }

    public void PasswordEdit_Click(object obj, RoutedEventArgs args)
    {
        _viewModel.PasswordEdit();
        if (_viewModel.State == StateEditPassword.Ok)
            Content = new ProfileEditerPage();
    }


}