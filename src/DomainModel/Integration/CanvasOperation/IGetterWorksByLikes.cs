using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IGetterWorksByLikes
	{
		Task<IEnumerable<CanvasResult>> GetCanvas(int userId, RangeTakeAndSkip range);
		Task<IEnumerable<VersionProjectResult>> GetVersionProject(int userId, RangeTakeAndSkip range);
	}
}
