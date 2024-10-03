using DomainModel.Model;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
    public class Entrance : IEntrance
	{
		public Role IputSystem(string login, string password)
		{
			try
			{
				IEntranceControllerIntegration entranceController = new EntranceControllerIntegration();
				var code = entranceController.GetCode(login, password);
				
				return new Role();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			throw new NotImplementedException();
		}
	}
}
