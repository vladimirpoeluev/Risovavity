
namespace InteractiveApiRisovaviti.Interface
{
	public interface IAuthenticationUserByRefresh : IAuthenticationUser
	{
		Task TryUpdateToken(ref bool isValid);
	}
}
