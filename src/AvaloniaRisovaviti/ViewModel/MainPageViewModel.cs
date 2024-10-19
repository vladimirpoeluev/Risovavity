using Avalonia.Controls;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.IO;
using Avalonia.Media;
using System;
using AvaloniaRisovaviti.ProfileShows;

namespace AvaloniaRisovaviti.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public UserResult UserResult { get; set; }
		public IImage Image { get; set; }

		public MainPageViewModel() 
		{
			Profile profile = new Profile(Authentication.AuthenticationUser.User);
			InitUser(profile);	
		}

		private void InitUser(Profile profile)
		{
			UserResult = profile.ProfileUser;
			try
			{
				var bytes = profile.ProfileAvatar.AvatarResult;
				Image = ImageAvaloniaConverter.ConvertByteInImage(bytes);
			}
			catch (Exception)
			{
				Image = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
			}
		}

		#region INotifyPropertyChanged Implementation
		public event PropertyChangedEventHandler? PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string? name = null)
		{
			if (name != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}
		#endregion
	}


}

