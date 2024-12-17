using Fizzler;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;
using System.Text;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class AuthenticationUserByRefresh : IAuthenticationUserByRefresh, IAuthenticationUserForSave
	{
		FabricAutoControllerIntegraion _fabricAuto;
		TokensRefreshAndAccess _tokens;

		public AuthenticationUserByRefresh(TokensRefreshAndAccess tokens, FabricAutoControllerIntegraion fabricAuto)
		{
			_tokens = tokens;
			_fabricAuto = fabricAuto;
		}

		Stream IAuthenticationUserForSave.Stream => new MemoryStream(Encoding.UTF8.GetBytes(_tokens.Access));

		void IAuthenticationUser.SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _tokens.Access);
		}

		async Task<bool> IAuthenticationUserByRefresh.TryUpdateToken()
		{
			try
			{
				TokensRefreshAndAccess tokens = await _fabricAuto
					.CreateGetPatser(new AuthenticationUser(_tokens.Refresh))
					.GetResultAsync<TokensRefreshAndAccess>("api/Auto/access");
				return true;
			}
			catch (Exception) 
			{
				return false;
			}
		}
	}
}
