using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;

namespace InteractiveApiRisovaviti
{
	public class SesstionService : ISessionService
	{
		private FabricAutoControllerIntegraion _fabricOperate;
		private IAuthenticationUser _user;

		public SesstionService(FabricAutoControllerIntegraion fabricOperate, IAuthenticationUser user) 
		{
			_fabricOperate = fabricOperate;
			_user = user;
		}

		public async Task DeleteAllSessionAsync()
		{
			IPostAutoControllerIntegraion post = _fabricOperate.CreatePostPatser<object>(_user, null);
			await post.ExecuteRequestAsync("api/Session/delete");
		}

		public async Task DeleteSessionAsync(string refresh)
		{
			IPostAutoControllerIntegraion post = _fabricOperate.CreatePostPatser(_user, refresh);
			await post.ExecuteRequestAsync("api/Session/delete-by-refresh");
		}

		public async Task DeleteSesstionAsync()
		{
			IPostAutoControllerIntegraion post = _fabricOperate.CreatePostPatser<object>(_user, null);
			await post.ExecuteRequestAsync("api/Session/delete/all-except-current");
		}

		public async Task<IEnumerable<SessionAuthorizeObject>> GetSessionAsync()
		{
			IGetAutoControllerIntegraion get = _fabricOperate.CreateGetPatser(_user);
			return await get.GetResultAsync<IEnumerable<SessionAuthorizeObject>>("api/Session/get");
		}
	}
}
