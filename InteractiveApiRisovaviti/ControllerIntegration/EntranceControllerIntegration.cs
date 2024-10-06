﻿
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DomainModel.ResultsRequest.Error;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration
{
    internal class EntranceControllerIntegration : GetControllerIntegration, IEntranceControllerIntegration
    {
        private string Password { get; set; } = string.Empty;
        private string Login { get; set; } = string.Empty;

        public EntranceControllerIntegration(IAuthenticationUser user) : base(user)
        {

        }

        public string EntranceSystem(string login, string password)
        {
            Login = login;
            Password = password;
            HttpResponseMessage message = GetResponseMessage();
            CheckStatusCode(message);
            var result = message.Content.ReadAsAsync<String>().Result;
            return result;
        }

        protected override HttpResponseMessage StartRequest(IApiRequest client)
        {
            return client.GetRequest($"api/Entrance/input?login={Login}&password={Password}");
        }
    }
}
