using DomainModel.ResultsRequest;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel.Main
{
	internal class RegistrationPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        string _error;
        public RegistrationForm RegistrationForm { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
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

        [Reactive]
        public IEnumerable<string> Errors { get; set; }

        public RegistrationPageViewModel()
        {
            RegistrationForm = new RegistrationForm();
            _error = string.Empty;
            RepeatPassword = string.Empty;
            Errors = new List<string>();
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