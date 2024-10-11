using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaRisovaviti.ViewModel;
using InteractiveApiRisovaviti;

namespace AvaloniaRisovaviti;

public partial class ProfileEditerPage : UserControl
{
    ProfileEditerPageViewModel viewModel;
    public ProfileEditerPage()
    {
        InitializeComponent();
        viewModel = new ProfileEditerPageViewModel();
        DataContext = viewModel;
    }

    public void EditProfile(object obj, RoutedEventArgs args)
    {
        Profile profile = new Profile(Authentication.AuthenticationUser.User);
        profile.ProfileUser = viewModel.UserResult;
    }
}