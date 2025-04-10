using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace AvaloniaRisovaviti.ViewModel.Profile
{
    internal class ProfileEditerPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IImage _image;
        public UserResult UserResult { get; set; } = new UserResult();
        public IImage Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public ProfileEditerPageViewModel()
        {
            Image = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
            
        }
		public override void Load()
		{
			base.Load();
			InitUserProfile();
		}

		public void InitUserProfile()
        {
            TryAction(() =>
            {
				InteractiveApiRisovaviti.Profile profile = new(Authentication.AuthenticationUser.User);
				ProfileSetterImage setterImage = new ProfileSetterImage(profile);
				UserResult = profile.ProfileUser;
				Image = setterImage.UpdateImage();
			});
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