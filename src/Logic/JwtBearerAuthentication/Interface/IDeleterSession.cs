namespace Logic.JwtBearerAuthentication.Interface
{
	public interface IDeleterSession
	{
		Task DeleteSession(string refresh);
	}
}
