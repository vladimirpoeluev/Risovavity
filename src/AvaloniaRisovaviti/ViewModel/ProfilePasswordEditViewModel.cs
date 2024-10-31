using AvaloniaRisovaviti.Validaters;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class ProfilePasswordEditViewModel: INotifyPropertyChanged
    {
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string RepeatNewPassword { get; set; } = string.Empty;
        public string ErrorMessage {  get; set; } = string.Empty;
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
				ErrorMessage = $"Ошибка валидации пароля: {valider.Error.FirstOrDefault()}";
			}
			return valider.IsValid;
        }

        void TryPasswordUpdate()
        {
            try
            {
				_passwordEditer.PasswordUpdate(OldPassword, NewPassword);
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