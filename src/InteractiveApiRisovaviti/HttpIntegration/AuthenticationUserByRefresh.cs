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
		protected virtual string NameOfApp { get; set; } = Environment.MachineName;
		protected virtual string VersionOfApp { get; set; } = "0.3.3";

		public AuthenticationUserByRefresh(TokensRefreshAndAccess tokens, FabricAutoControllerIntegraion fabricAuto)
		{
			_tokens = tokens;
				_fabricAuto = fabricAuto;
		}

		Stream IAuthenticationUserForSave.Stream => new MemoryStream(Encoding.UTF8.GetBytes(_tokens.Access));

		void IAuthenticationUser.SettingUpDataProvisioning(HttpClient client)
		{
			client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(NameOfApp, VersionOfApp));
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _tokens.Access);
		}

		async Task<bool> IAuthenticationUserByRefresh.TryUpdateToken()
		{
			try
			{
				TokensRefreshAndAccess tokens = await _fabricAuto
					.CreateGetPatser(new AuthenticationUser(_tokens.Refresh))
					.GetResultAsync<TokensRefreshAndAccess>("api/Auto/access");
				_tokens = tokens;
				return true;
			}
			catch (Exception) 
			{
				return false;
			}
		}
	}
}
