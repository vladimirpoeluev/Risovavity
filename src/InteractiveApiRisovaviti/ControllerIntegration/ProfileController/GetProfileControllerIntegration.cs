using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.ProfileController
{
    internal class GetProfileControllerIntegration : GetControllerIntegration, IGetProfileControllerIntegration
    {
        public GetProfileControllerIntegration(IAuthenticationUser user) : base(user)
        {
        }

        public UserResult GetProfile()
        {
            var message = GetResponseMessage();
            UserResult result = message.Content.ReadAsAsync<UserResult>().Result;
            return result;
        }

        protected override HttpResponseMessage StartRequest(IApiRequest client)
        {
            var request = client.GetRequest("api/profile");
            CheckStatusCode(request);
            return request;
        }


    }
}
