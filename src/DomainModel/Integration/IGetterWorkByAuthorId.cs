using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration
{
    public interface IGetterWorkByAuthorId
    {
		Task<IEnumerable<CanvasResult>> GetCanvasByAuthorId(int id, int skip, int take);
		Task<IEnumerable<VersionProjectResult>> GetVersionProjectResultsByAuthorId(int id, int skip, int take);
	}
}
