
using DomainModel.Integration;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class TwoFactorAuthService : ITwoFactorAuthService
	{
		FabricAutoControllerIntegraion controllerIntegraion;
		IAuthenticationUser User { get; set; }
		public TwoFactorAuthService(FabricAutoControllerIntegraion fabricAuto, IAuthenticationUser user) 
		{
			controllerIntegraion = fabricAuto;
			User = user;
		}

		public async Task<bool> GetAsync()
		{
			return await controllerIntegraion.CreateGetPatser(User).GetResultAsync<bool>("api/settings-auth/get-auth");
		}

		public async Task SetAsync(bool value)
		{
			await controllerIntegraion.CreatePostPatser<object>(User, null).ExecuteRequestAsync($"api/settings-auth/set-auth/{value}");
		}
	}
}
