using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class ProfileEditerPageViewModel: INotifyPropertyChanged
    {
        public UserResult UserResult { get; set; } = new UserResult();

        public ProfileEditerPageViewModel()
        {
            UserResult = new Profile(Authentication.AuthenticationUser.User).ProfileUser;
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