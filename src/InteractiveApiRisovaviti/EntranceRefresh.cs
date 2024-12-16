
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class EntranceRefresh : IEntrance
	{
		FabricAutoControllerIntegraion _integration;
		public EntranceRefresh(FabricAutoControllerIntegraion integration)
		{
			_integration = integration;
		}
		IAuthenticationUser IEntrance.IputSystem(string login, string password)
		{
			throw new NotImplementedException();
		}
	}
}
