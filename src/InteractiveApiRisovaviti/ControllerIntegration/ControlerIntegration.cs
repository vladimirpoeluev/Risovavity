﻿using DomainModel.ResultsRequest.Error;
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

		protected static void CheckStatusCode(HttpResponseMessage message)
		{
            
			try
            {
                TryCheckStatusCode(message);
            }
            catch 
            {
                AlternativeErrorDisplay(message);
            }
		}

        private static void TryCheckStatusCode(HttpResponseMessage message) 
        {
			if (message.StatusCode != HttpStatusCode.OK)
			{
				var result = message.Content.ReadAsAsync<ErrorMessageRequest>().Result;
				throw new Exception($"Code: {result.NumberError} Message: {result.Message}");
			}
		}

        private static void AlternativeErrorDisplay(HttpResponseMessage message)
        {
			var result = message.Content.ReadAsStringAsync().Result;
			throw new Exception(result);
        }

	}
}
