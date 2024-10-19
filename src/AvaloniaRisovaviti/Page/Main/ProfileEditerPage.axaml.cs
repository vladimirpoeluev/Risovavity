using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using AvaloniaRisovaviti.ViewModel;
using InteractiveApiRisovaviti;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;

namespace AvaloniaRisovaviti;

public partial class ProfileEditerPage : UserControl
{
    ProfileEditerPageViewModel viewModel;
	Profile Profile { get; set; }
    public ProfileEditerPage()
    {
        InitializeComponent();
        viewModel = new ProfileEditerPageViewModel();
        DataContext = viewModel;
		Profile = new Profile(Authentication.AuthenticationUser.User);
	}

    public void EditProfile(object obj, RoutedEventArgs args)
    {
        Profile.ProfileUser = viewModel.UserResult;
    }

    public async void Click_MenuImage(object obj, RoutedEventArgs args) 
    {
		var topLevel = TopLevel.GetTopLevel(this);

		// Start async operation to open the dialog.
		var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
		{
			Title = "Open Text File",
			AllowMultiple = false
		});

		if (files.Count >= 1)
		{
			// Open reading stream from the first file.
			await using var stream = await files[0].OpenReadAsync();
			var avatar = Profile.ProfileAvatar;
			var converter = new ImageConverter();
			avatar.AvatarResult = (byte[])converter.ConvertTo(new Bitmap(stream), typeof(byte[]));
			// Reads all the content of file as a text.
			Profile.ProfileAvatar = avatar;
		}
	}
}