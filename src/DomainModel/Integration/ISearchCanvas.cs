
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration
{
	public interface ISearcherCanvas
	{
		Task<IEnumerable<CanvasResult>> Search(string keyworld);
	}
}
