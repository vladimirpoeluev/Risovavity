
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration
{
	public interface IDefinitionerOfPermission
	{
		Task<PermissionResult> GetPermissionAsync(UserResult user, CanvasResult canvas);
		Task<PermissionResult> GetPermissionAsync(UserResult user, VersionProjectResult versionProject);
	}
}
