
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IGetterVersionByParentVersion
	{
		Task<IEnumerable<VersionProjectResult>> GetVersionsByParent(VersionProjectResult parent);
	}
}
