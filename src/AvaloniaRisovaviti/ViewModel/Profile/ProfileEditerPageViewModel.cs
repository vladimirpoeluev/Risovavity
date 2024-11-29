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
    internal class ProfileEditerPageViewModel : INotifyPropertyChanged
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
            InitUserProfile();
        }

        public void InitUserProfile()
        {
            try
            {
				InteractiveApiRisovaviti.Profile profile = new(Authentication.AuthenticationUser.User);
                ProfileSetterImage setterImage = new ProfileSetterImage(profile);
                UserResult = profile.ProfileUser;
                Image = setterImage.UpdateImage();
            }
            catch (Exception)
            {
                UserResult = new UserResult()
                {
                    Name = "������������ �� �������",
                    Email = "������ ����������",
                    IdRoleNavigation = new RoleResult() { Name = "���� �� ��������" }
                };

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