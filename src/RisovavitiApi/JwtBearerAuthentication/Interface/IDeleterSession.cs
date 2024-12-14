namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
	public interface IDeleterSession
	{
		Task DeleteSession(string refresh);
	}
}
