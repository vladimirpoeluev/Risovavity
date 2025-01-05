using DomainModel.Model;
using Logic.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class InputSystemRefresh : IInputerSystem, IGeneraterAccessByRefresh
	{
		IAdderSessionByRefresh AdderSession { get; set; }
		IGetterSessionByRefresh GetterSession { get; set; }
		IHttpContextAccessor _context;
		string RefreshToken { get; set; }

		public InputSystemRefresh(IAdderSessionByRefresh adder, IGetterSessionByRefresh getter, IHttpContextAccessor context) 
		{
			AdderSession = adder;
			GetterSession = getter;
			RefreshToken = string.Empty;
			_context = context;
		}

		public string InputUser(User user)
		{
			return InputUserAsync(user).Result;
		}

		public async Task<string> InputUserAsync(User user)
		{
			string result = await AdderSession.AddSession(new SessionAuthorizeObject()
			{
				UserId = user.Id,
				Descrition = _context.HttpContext?.Request.Headers["User-Agent"].ToString() ?? "Неопознаный объект"
			});
			RefreshToken = AdderSession.Refresh.ToString();
			return result;
		}

		public IInputerSystem GetAccessToken(IInputerSystem inputer)
		{
			if(inputer is IInputerSystemWithRefresh)
			{
				var inputerWithRefresh = (IInputerSystemWithRefresh)inputer;
				inputerWithRefresh.RefreshToken = RefreshToken;
			}
			return inputer;
		}
	}
}
