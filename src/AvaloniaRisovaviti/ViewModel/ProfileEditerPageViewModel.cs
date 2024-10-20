using Avalonia.Media;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class ProfileEditerPageViewModel: INotifyPropertyChanged
    {
        public UserResult UserResult { get; set; } = new UserResult();
        public IImage Image { get; set; }

        public ProfileEditerPageViewModel()
        {

			Image = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");

			try
            {
				Profile profile = new Profile(Authentication.AuthenticationUser.User);
				ProfileSetterImage setterImage = new ProfileSetterImage(profile);
				UserResult = profile.ProfileUser;
				Image = setterImage.UpdateImage();
			}
            catch (Exception)
            {
                UserResult = new UserResult() 
                { 
                    Name = "Пользователь не опознан",
                    Email = "Данные неопознаны",
                    IdRoleNavigation = new RoleResult() {  Name = "Роль не опознана"}
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