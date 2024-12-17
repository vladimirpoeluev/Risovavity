
namespace InteractiveApiRisovaviti.Interface
{
	public interface IAuthenticationUserByRefresh : IAuthenticationUser
	{
		Task<bool> TryUpdateToken();
	}
}
