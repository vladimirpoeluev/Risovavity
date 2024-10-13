using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration.EntranceController;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Registration : IRegistarion
	{
		IRegistraionController _controller;
		public Registration(IAuthenticationUser user)
		{
			_controller = new RegistrationController(user);
		}
		void IRegistarion.RegistrionUser(RegistrationForm form)
		{
			_controller.RegistrationSystem(form);
		}
	}
}
