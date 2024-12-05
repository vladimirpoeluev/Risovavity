using DomainModel.ResultsRequest.Error;
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
            return await StartRequestAsync(SettingApiRequest());
        }

		protected static void CheckStatusCode(HttpResponseMessage message)
		{
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
