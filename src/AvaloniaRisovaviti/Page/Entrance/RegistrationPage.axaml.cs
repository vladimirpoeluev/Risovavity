using Avalonia.Controls;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti;
using AvaloniaRisovaviti.ViewModel;

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
            _registarion.RegistrionUser(_viewModel.RegistrationForm);
			this.Content = new MainPage();
		}

        void ErrorRegistration()
        {

        }
    }
}
