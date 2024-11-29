using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel.Main
{
    internal class EntrancePageViewModel : INotifyPropertyChanged
    {
        string _error = string.Empty;
        public string Login { get; set; }
        public string Password { get; set; }
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        public EntrancePageViewModel()
        {
            Login = string.Empty;
            Password = string.Empty;
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