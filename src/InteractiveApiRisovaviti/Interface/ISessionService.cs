
using InteractiveApiRisovaviti.Models;

namespace InteractiveApiRisovaviti.Interface
{
	public interface ISessionService
	{
		Task DeleteSessionAsync(string refresh);
		Task DeleteSesstionAsync();
		Task DeleteAllSessionAsync();
		Task<IEnumerable<SessionAuthorizeObject>> GetSessionAsync();
	}
}
