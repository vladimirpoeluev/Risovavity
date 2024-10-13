using DomainModel.ResultsRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class RegistrationPageViewModel: INotifyPropertyChanged
    {
        public RegistrationForm RegistrationForm { get; set; }
        public string Error { get; set; }

        public RegistrationPageViewModel()
        {
            RegistrationForm = new RegistrationForm();
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