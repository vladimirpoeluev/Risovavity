using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.ResultsRequest;
using ReactiveUI.Fody.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel.Profile
{
	internal class ProfileEditerPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IImage _image;
        [Reactive]
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

        public ProfileEditerPageViewModel()
        {
            Image = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
            UserResult = new UserResult();
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
            OnPropertyChanged(nameof(UserResult));
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