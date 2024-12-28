using Logic.Interface;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
	public interface IInputerSystemWithRefresh : IInputerSystem
	{
		string RefreshToken { get; set; }
	}
}
