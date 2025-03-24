using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;

namespace Logic.CanvasLogic;
class GetterWorksByLikes : IGetterWorksByLikes
{

	public Task<IEnumerable<CanvasResult>> GetCanvas(int userId)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<VersionProjectResult>> GetVersionProject(int userId)
	{
		throw new NotImplementedException();
	}
}