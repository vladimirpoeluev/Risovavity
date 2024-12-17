using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.ControllerIntegration.EntranceController;

namespace InteractiveApiRisovaviti
{
    public class Entrance : IEntrance
	{
		public Task<IAuthenticationUser> InputSystemAsync(string login, string password)
		{
			throw new NotImplementedException();
		}

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
