using AvaloniaRisovaviti.Validaters;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace AvaloniaRisovaviti.ViewModel
{
    enum StateEditPassword 
    {
        Ok,
        Error,
        None
    }
    internal class ProfilePasswordEditViewModel: INotifyPropertyChanged
    {
        string _errorMessage;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string RepeatNewPassword { get; set; } = string.Empty;
        public StateEditPassword State {  get; set; } = StateEditPassword.None;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private IPasswordEditer _passwordEditer;

        public ProfilePasswordEditViewModel() 
        {
            _passwordEditer = new Profile(Authentication.AuthenticationUser.User);
		}

        public void PasswordEdit()
        {
            if (ValidPasswords())
            {
                TryPasswordUpdate();
            }
        }

        bool ValidPasswords()
        {
            var valider = ValidaterPassword.CreateValidaterPassword(NewPassword);
            if(!valider.IsValid)
            {
				ErrorMessage = $"Ошибка валидации пароля: {valider.Error.FirstOrDefault() ?? "Ошибка поиска ошибки"}";
			}
            if(NewPassword != RepeatNewPassword)
            {
                ErrorMessage = $"Ошибка валидации: новый пароль и повтор нового пароля разные";
                return false;
            }
			return valider.IsValid;
        }

        void TryPasswordUpdate()
        {
            try
            {
				_passwordEditer.PasswordUpdate(OldPassword, NewPassword);
                State = StateEditPassword.Ok;
			}
            catch (Exception)
            {
                ErrorMessage = "Произошла ошибка возможно несоответсвие текущего пароля";
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