using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class EntrancePageViewModel: INotifyPropertyChanged
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Error { get; set; }

        public EntrancePageViewModel() 
        {
            Login = string.Empty;
            Password = string.Empty;
            Error = string.Empty;
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