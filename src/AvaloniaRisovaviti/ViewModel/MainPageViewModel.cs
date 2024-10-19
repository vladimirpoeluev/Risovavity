using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;
using System.Drawing;

namespace AvaloniaRisovaviti.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		IImage _image;
		public UserResult UserResult { get; set; }
		public IImage Image 
		{ 
			get => _image; 
			set 
			{
				_image = value;
				OnPropertyChanged(nameof(Image));
			} 
		}
		private ProfileSetterImage _setterImage;

		public MainPageViewModel() 
		{
			Profile profile = new Profile(Authentication.AuthenticationUser.User);
			_setterImage = new ProfileSetterImage(profile);
			InitUser(profile);
		}

		private void InitUser(Profile profile)
		{
			UserResult = profile.ProfileUser;
			Image = _setterImage.UpdateImage();
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

