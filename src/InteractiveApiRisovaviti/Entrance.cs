using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.ControllerIntegration;

namespace InteractiveApiRisovaviti
{
    public class Entrance : IEntrance
	{
		public IAuthenticationUser IputSystem(string login, string password)
		{
			try
			{
				IEntranceControllerIntegration entranceController = new EntranceControllerPost(AuthenticationUser.NotAuthenticationUser);
				var code = entranceController.EntranceSystem(login, password);
				
				return new AuthenticationUser(code);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				throw new Exception(ex.Message);
			}
		}
	}
}
