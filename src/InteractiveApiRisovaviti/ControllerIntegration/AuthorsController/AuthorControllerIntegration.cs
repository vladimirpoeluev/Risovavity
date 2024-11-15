using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.AuthorsController
{
    class AuthorControllerIntegration : GetControllerIntegration, IAuthorControllerIntegration
    {
        public AuthorControllerIntegration(IAuthenticationUser user) : base(user)
        { }

        public IEnumerable<AuthorResult> GetAuthors()
        {
            var message = GetResponseMessage();
            CheckStatusCode(message);
            return message.Content.ReadAsAsync<IEnumerable<AuthorResult>>().Result;
        }

        protected override HttpResponseMessage StartRequest(IApiRequest client)
        {
            return client.GetRequest("api/authors/get");
        }

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}
