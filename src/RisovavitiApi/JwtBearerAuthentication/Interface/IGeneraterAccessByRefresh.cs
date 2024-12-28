using Logic.Interface;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
	public interface IGeneraterAccessByRefresh
	{
		IInputerSystem GetAccessToken(IInputerSystem inputer);
	}
}
