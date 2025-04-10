using Autofac;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.ProfileShows;
using AvaloniaRisovaviti.ViewModel.Profile;
using InteractiveApiRisovaviti;

namespace AvaloniaRisovaviti;

public partial class ProfileEditerPage : View
{
    ProfileEditerPageViewModel viewModel;
	Profile Profile { get; set; }
    public ProfileEditerPage()
    {
        InitializeComponent();
        viewModel = new ProfileEditerPageViewModel();
        ViewModel = viewModel;
		Profile = new Profile(Authentication.AuthenticationUser.User);
	}

    public void EditProfile(object obj, RoutedEventArgs args)
    {
        Profile.ProfileUser = viewModel.UserResult;
    }

    public async void Click_MenuImage(object obj, RoutedEventArgs args) 
    {
		var topLevel = TopLevel.GetTopLevel(this);
		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Open Text File",
			AllowMultiple = false
		});

		if (files.Count >= 1)
		{
			await using var stream = await files[0].OpenReadAsync();
			var avatar = Profile.ProfileAvatar;
			avatar.AvatarResult = ImageAvaloniaConverter.ConvertImageInByte(stream);
			Profile.ProfileAvatar = avatar;
		}
		viewModel.InitUserProfile();
	}

	public void NavEditPassword_Click(object obj, RoutedEventArgs args)
	{
		Content = App.Container.Resolve<SettingsView>();
	}
}