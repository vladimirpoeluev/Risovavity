using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;

namespace InteractiveApiRisovaviti.Interface
{
    public interface IDefinitionerOfPermission
    {
        Task<PermissionResult> GetPermissionAsync(CanvasResult canvas);
        Task<PermissionResult> GetPermissionAsync(VersionProjectResult versionProject);
    }
}