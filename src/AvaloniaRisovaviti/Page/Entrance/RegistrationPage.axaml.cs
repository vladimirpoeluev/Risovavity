using Avalonia.Controls;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel.Main;
using Autofac;
using AvaloniaRisovaviti.Page.Main;
using System.Linq;

namespace AvaloniaRisovaviti
{
    public partial class RegistrationPage : View
    {
		RegistrationPageViewModel _viewModel;
        IRegistarion _registarion;
        public RegistrationPage()
        {   
            InitializeComponent();
            _viewModel = new RegistrationPageViewModel();
            ViewModel = _viewModel;
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
            if (_viewModel.RegistrationForm.Password == _viewModel.RepeatPassword)
            {
               // _registarion.RegistrionUser(_viewModel.RegistrationForm);
                var vm = App.Container.Resolve<ConfimationEmailViewModel>();
                vm.Email = _viewModel.RegistrationForm.Email;

                var page = new ConfimationEmailView(vm);

				this.Content = page;
			}
            else
            {
				_viewModel.Errors = _viewModel.Errors.Append("������ �� �������");
            }
            
		}

        void ErrorRegistration()
        {
            _viewModel.Errors = _viewModel.Errors.Append("������ ������������ � ���� ������� ��� ���������� ���������� ������� ����� �����");
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
            Content = App.Container.Resolve<EntrancePage>();
        }

	}
}
