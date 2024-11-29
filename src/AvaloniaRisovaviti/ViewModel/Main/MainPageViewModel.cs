using DomainModel.ResultsRequest;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;

namespace AvaloniaRisovaviti.ViewModel.Main
{
    public class MainPageViewModel : INotifyPropertyChanged
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
            _profile = new(Authentication.AuthenticationUser.User);
            _setterImage = new ProfileSetterImage(_profile);
            InitUser();
        }

        public void InitUser()
        {
            UserResult = _profile.ProfileUser;
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

