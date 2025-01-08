using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;

namespace RisovavitiApi.Model.Interfaces
{
    public interface IDefinitionerOfPermissionByHttpContext
    {
        Task<PermissionResult> GetPermissionResult(CanvasResult canvasResult);
        Task<PermissionResult> GetPermissionResult(VersionProjectResult versionProject);
    }
}