using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IAdderVersionProject
	{
		Task AddVertionProjectAsync(VersionProjectForAddResult result);
		Task DeleteVertionProjectAsync(int id);
	}
}
