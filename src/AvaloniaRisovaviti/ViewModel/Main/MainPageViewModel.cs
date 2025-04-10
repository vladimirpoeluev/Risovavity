using DomainModel.ResultsRequest;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;

namespace AvaloniaRisovaviti.ViewModel.Main
{
    public class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IImage _image;
        InteractiveApiRisovaviti.Profile _profile;
        UserResult _userResult;
        public UserResult UserResult
        {
            get => _userResult;
            set
            {
                _userResult = value;
                OnPropertyChanged(nameof(UserResult));
            }
        }
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
            try
            {
				_profile = new(Authentication.AuthenticationUser.User);
				_setterImage = new ProfileSetterImage(_profile);
				
			}
            catch
            {
				new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
			}
        }
		public override void Load()
		{
            
			InitUser();
			base.Load();
		}

		public void InitUser()
        {
            TryAction(() =>
            {
				UserResult = _profile.ProfileUser;
				Image = _setterImage.UpdateImage();
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

