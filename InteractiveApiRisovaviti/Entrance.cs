using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.HttpIntegration;

namespace InteractiveApiRisovaviti
{
    public class Entrance : IEntrance
	{
		public IAuthenticationUser IputSystem(string login, string password)
		{
			try
			{
				IEntranceControllerIntegration entranceController = new EntranceControllerIntegration(AuthenticationUser.NotAuthenticationUser);
				var code = entranceController.EntranceSystem(login, password);
				
				return new AuthenticationUser(code);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			throw new NotImplementedException();
		}
	}
}
