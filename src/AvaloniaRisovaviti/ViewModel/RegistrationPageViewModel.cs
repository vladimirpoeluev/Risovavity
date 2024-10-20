using DomainModel.ResultsRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class RegistrationPageViewModel: INotifyPropertyChanged
    {
        string _error;
        public RegistrationForm RegistrationForm { get; set; }
        public string RepeatPassword { get; set; }
		public string Error 
        {
            get => _error;
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            } 
        }

        public RegistrationPageViewModel()
        {
            RegistrationForm = new RegistrationForm();
            _error = string.Empty;
            RepeatPassword = string.Empty;
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