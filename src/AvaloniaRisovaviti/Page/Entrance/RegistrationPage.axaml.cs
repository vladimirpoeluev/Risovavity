using Avalonia.Controls;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel.Main;
using Autofac;

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


        private void Regist_Click(object? obj, RoutedEventArgs routedEvent)
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
				this.Content = App.Container.Resolve<IEntrance>();
			}
            else
            {
                _viewModel.Error = "������ �� �������";
            }
            
		}

        void ErrorRegistration()
        {
            _viewModel.Error = "������ ������������ � ���� ������� ��� ���������� ���������� ������� ����� �����";
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
            Content = App.Container.Resolve<IEntrance>();
        }

	}
}
