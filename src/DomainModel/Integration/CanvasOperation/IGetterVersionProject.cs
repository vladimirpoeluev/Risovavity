
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IGetterVersionProject
	{
		Task<VersionProjectResult> GetVersionProjectByIdAsync(int id);
		Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(string projectName);
		Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(int skip, int take);
	}
}
