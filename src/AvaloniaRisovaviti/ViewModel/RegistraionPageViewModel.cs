using DomainModel.ResultsRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class RegistraionPageViewModel: INotifyPropertyChanged
    {
        public RegistrationForm RegistrationForm { get; set; }

        public RegistraionPageViewModel()
        {
            RegistrationForm = new RegistrationForm();
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