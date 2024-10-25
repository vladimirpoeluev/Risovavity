using Avalonia.Controls;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti;
using AvaloniaRisovaviti.ViewModel;
using Avalonia.Interactivity;

namespace AvaloniaRisovaviti
{
    public partial class RegistrationPage : UserControl
    {
		RegistrationPageViewModel _viewModel;
        IRegistarion _registarion;
        public RegistrationPage()
        {   
            InitializeComponent();
            _viewModel = new RegistrationPageViewModel();
            DataContext = _viewModel;
            _registarion = new Registration(Authentication.AuthenticationUser.User);
        }


        private void Regist_Click(object? obj, Avalonia.Interactivity.RoutedEventArgs routedEvent)
        {
            try
            {
                TryRegistration();
            }
            catch
            {
                ErrorRegistration();
            }
            
        }

        void TryRegistration()
        {
            if(_viewModel.RegistrationForm.Password == _viewModel.RepeatPassword)
            {
				_registarion.RegistrionUser(_viewModel.RegistrationForm);
				this.Content = new EntrancePage();
			}
            else
            {
                _viewModel.Error = "Пароли не совпали";
            }
            
		}

        void ErrorRegistration()
        {
            _viewModel.Error = "Похоже пользователь с таки логином уже существует попробуйте создать новый логин";
        }

        public  void CheckedConfidicialnosti(object? obj, RoutedEventArgs e)
        {
			buttnReg.IsEnabled = true;

		}

        public void UnCheckedConfidicialnosti(object? obj, RoutedEventArgs e)
        {
			buttnReg.IsEnabled = false;
		}

        public void Back_Click(object? obj, RoutedEventArgs e)
        {
            Content = new EntrancePage();
        }

	}
}
