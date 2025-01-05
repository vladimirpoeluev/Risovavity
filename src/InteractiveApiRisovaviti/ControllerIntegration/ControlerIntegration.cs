using DomainModel.ResultsRequest.Error;
using InteractiveApiRisovaviti.Exceptions;
using InteractiveApiRisovaviti.Interface;
using System.Net;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
    internal abstract class ControlerIntegration
    {
        public IAuthenticationUser User { get; set; }

        public ControlerIntegration(IAuthenticationUser user)
        {
            User = user;
        }

        protected abstract IApiRequest SettingApiRequest();

        protected abstract HttpResponseMessage StartRequest(IApiRequest client);
        protected abstract Task<HttpResponseMessage> StartRequestAsync(IApiRequest client);

        protected HttpResponseMessage GetResponseMessage()
        {
            return StartRequest(SettingApiRequest());
        }

        protected async Task<HttpResponseMessage> GetResponseAsync()
        {
            HttpResponseMessage message = await StartRequestAsync(SettingApiRequest());
            try
            {
                CheckStatusCode(message);
                return message;
            }
            catch (AuthorizeException) 
            {
				if (message.StatusCode == HttpStatusCode.Unauthorized &&
					User is IAuthenticationUserByRefresh)
				{
					if (await ((IAuthenticationUserByRefresh)User).TryUpdateToken())
					{
				        return await StartRequestAsync(SettingApiRequest());
					}
				}
            }
            return message;
        }

		protected void CheckStatusCode(HttpResponseMessage message)
		{
            if(message.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new AuthorizeException();
            }
			if (message.StatusCode != HttpStatusCode.OK)
			{
				var result = TryCheckStatusCode(message);
				throw new Exception($"Code: {result?.NumberError ?? 0} Message: {result?.Message ?? message.StatusCode.ToString()}");
			}
		}

        private static ErrorMessageRequest TryCheckStatusCode(HttpResponseMessage message) 
        {
            try
            {
				return message.Content.ReadAsAsync<ErrorMessageRequest>().Result;
			}
			catch
			{
				return AlternativeErrorDisplay(message);
			}
		}

        private static ErrorMessageRequest AlternativeErrorDisplay(HttpResponseMessage message)
        {
			var result = message.Content.ReadAsStringAsync().Result;
			throw new Exception(result);
        }

	}
}
