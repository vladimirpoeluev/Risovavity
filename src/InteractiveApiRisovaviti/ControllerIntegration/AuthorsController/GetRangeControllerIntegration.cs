
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.ControllerIntegration.AuthorsController
{
	internal class GetRangeControllerIntegration : GetControllerIntegration, IGetRangeControllerIntegration
	{
		private int Skip { get; set; }
		private int Take { get; set; }

		public GetRangeControllerIntegration(IAuthenticationUser user) : base(user) {}

		public IEnumerable<AuthorResult> GetRange(int skip, int take)
		{
			Skip = skip;
			Take = take;

			var message = GetResponseMessage();
			CheckStatusCode(message);

			return message.Content.ReadAsAsync<IEnumerable<AuthorResult>>().Result;
		}

		protected override HttpResponseMessage StartRequest(IApiRequest client)
		{
			return client.GetRequest($"/api/Authors/getRange?skip={Skip}&take={Take}");
		}

		protected override Task<HttpResponseMessage> StartRequestAsync(IApiRequest client)
		{
			throw new NotImplementedException();
		}
	}
}
