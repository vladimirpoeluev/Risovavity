
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class EntranceRefresh : IEntrance
	{
		public EntranceRefresh()
		{

		}
		IAuthenticationUser IEntrance.IputSystem(string login, string password)
		{
			throw new NotImplementedException();
		}
	}
}
