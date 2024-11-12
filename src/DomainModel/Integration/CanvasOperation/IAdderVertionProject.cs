using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IAdderVertionProject
	{
		Task AddVertionProjectAsync(VersionProjectForAddResult result);
		Task DeleteVertionProjectAsync(int id);
	}
}
