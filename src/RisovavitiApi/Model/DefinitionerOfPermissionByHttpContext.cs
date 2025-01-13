using DomainModel.Integration;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using RisovavitiApi.Model.Interfaces;
using RisovavitiApi.UserOperate;

namespace RisovavitiApi.Model
{
    public class DefinitionerOfPermissionByHttpContext : IDefinitionerOfPermissionByHttpContext
	{
		IDefinitionerOfPermission _definitioner;
		IHttpContextAccessor _contextAccessor;
		IRuleIntegrationUser _integrationUser;
		public DefinitionerOfPermissionByHttpContext(	IDefinitionerOfPermission definitioner, 
														IHttpContextAccessor contextAccessor,
														IRuleIntegrationUser integrationUser)
		{
			_definitioner = definitioner;
			_contextAccessor = contextAccessor;
			_integrationUser = integrationUser;
		}

		public async Task<PermissionResult> GetPermissionResult(CanvasResult canvasResult)
		{
			return await _definitioner.GetPermissionAsync(await GetUser(), canvasResult);
		}

		public async Task<PermissionResult> GetPermissionResult(VersionProjectResult versionProject)
		{
			return await _definitioner.GetPermissionAsync(await GetUser(), versionProject);
		}

		private async Task<UserResult> GetUser()
		{
			return await Task.Run(() =>
			{
				return UserGetterByContext.GetUserIntegration(_contextAccessor.HttpContext, _integrationUser);
			});
		}
	}
}
