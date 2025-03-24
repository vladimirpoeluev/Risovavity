using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IGetterWorksByLikes
	{
		Task<IEnumerable<CanvasResult>> GetCanvas(int userId);
		Task<IEnumerable<VersionProjectResult>> GetVersionProject(int userId);
	}
}
