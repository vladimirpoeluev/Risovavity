
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
    public class DefinitionerOfPermission : IDefinitionerOfPermission
	{
		IAuthenticationUser User { get; set; }
		FabricAutoControllerIntegraion _fabricAuto;
		public DefinitionerOfPermission(IAuthenticationUser user,
										FabricAutoControllerIntegraion fabricAuto)
		{
			User = user;
			_fabricAuto = fabricAuto;
		}

		public async Task<PermissionResult> GetPermissionAsync(CanvasResult canvas)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<PermissionResult>($"api/permission/canvas/{canvas.Id}");
		}

		public async Task<PermissionResult> GetPermissionAsync(VersionProjectResult versionProject)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<PermissionResult>($"api/permission/version-project/{versionProject.Id}");
		}
	}
}
