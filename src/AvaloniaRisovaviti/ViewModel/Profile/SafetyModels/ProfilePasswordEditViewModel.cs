using AvaloniaRisovaviti.Validaters;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using Autofac;
using ReactiveUI;
using MsBox.Avalonia;
using System.Threading.Tasks;
using System.Reactive.Linq;
using DynamicData.Binding;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Profile.SafetyModels
{
    enum StateEditPassword
    {
        Ok,
        Error,
        None
    }
    internal class ProfilePasswordEditViewModel : BaseViewModel, INotifyPropertyChanged
    {
        bool? isTwoAutentication;
        string _errorMessage;
        private DomainModel.Integration.ITwoFactorAuthService _twoFactorAuthService;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string RepeatNewPassword { get; set; } = string.Empty;
        public StateEditPassword State { get; set; } = StateEditPassword.None;
        [Reactive]
        public bool? TwoFactAuthentivation 
        {
            get;
            set;       
        }
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
            _passwordEditer = new InteractiveApiRisovaviti.Profile(Authentication.AuthenticationUser.User);
            _twoFactorAuthService = App.Container.Resolve<DomainModel.Integration.ITwoFactorAuthService>();
			TwoFactAuthentivation = false;
            InitTwoAuto();
            this.WhenAnyValue(vm => vm.TwoFactAuthentivation)
                .Where(isAuto => isAuto != null)
                .InvokeCommand(ReactiveCommand.Create(async (bool? isauto) => {
                    await TryActionAsync(async () =>
                    {
						await _twoFactorAuthService.SetAsync(isauto ?? false);
					});
                    return isauto ?? false;
                }));
        }

        private async void InitTwoAuto()
        {
            await TryActionAsync(async () =>
            {
				bool? istwoauto = await TryGetAutoAsync();

				if ((istwoauto) != null)
					TwoFactAuthentivation = istwoauto;
			});
				
            OnPropertyChanged(nameof(TwoFactAuthentivation));
        }   

        async Task<bool?> TryGetAutoAsync()
        {
            try
            {
                bool? isAuto = null;
                await TryActionAsync(async () =>
                {
                    isAuto = await _twoFactorAuthService.GetAsync();
                });
                return isTwoAutentication;
			}
            catch (Exception)
            {
				MessageBoxManager.GetMessageBoxStandard(new MsBox.Avalonia.Dto.MessageBoxStandardParams()
				{
					ContentMessage = "Произошла ошибка получения вида аутентификации пользователя",
					ContentTitle = "Ошибка",
					Icon = MsBox.Avalonia.Enums.Icon.Error
				});
                return null;
			}
            
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
            if (!valider.IsValid)
            {
                ErrorMessage = $"Ошибка валидации пароля: {valider.Error.FirstOrDefault() ?? "Ошибка поиска ошибки"}";
            }
            if (NewPassword != RepeatNewPassword)
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
                TryAction(() =>
                {
					_passwordEditer.PasswordUpdate(OldPassword, NewPassword);
				});
                
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