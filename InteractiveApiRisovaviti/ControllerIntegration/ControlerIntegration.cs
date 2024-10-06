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

        protected HttpResponseMessage GetResponseMessage()
        {
            return StartRequest(SettingApiRequest());
        }

		protected void CheckStatusCode(HttpResponseMessage message)
		{
			if (message.StatusCode != HttpStatusCode.OK)
			{
				var result = message.Content.ReadAsAsync<ErrorMessageRequest>().Result;
				throw new Exception($"Code: {(int)message.StatusCode} Message: {result}");
			}
		}
	}
}
