
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IGetterVersionByParentVersion
	{
		IEnumerable<VersionProjectResult> GetVersionsByParent(int idParent);
	}
}
