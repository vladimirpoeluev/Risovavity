using Logic.Interface;

namespace Logic.JwtBearerAuthentication.Interface
{
	public interface IInputerSystemWithRefresh : IInputerSystem
	{
		string RefreshToken { get; set; }
	}
}
