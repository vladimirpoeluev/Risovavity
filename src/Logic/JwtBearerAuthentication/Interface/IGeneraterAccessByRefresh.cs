using Logic.Interface;

namespace Logic.JwtBearerAuthentication.Interface
{
	public interface IGeneraterAccessByRefresh
	{
		IInputerSystem GetAccessToken(IInputerSystem inputer);
	}
}
