
using DomainModel.ResultsRequest;

namespace InteractiveApiRisovaviti.Interface
{
	internal interface IGetRangeControllerIntegration
	{
		IEnumerable<AuthorResult> GetRange(int skip, int take);
	}
}
