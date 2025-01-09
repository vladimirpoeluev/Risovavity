using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.Model.Interfaces;

namespace RisovavitiApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/permission")]
	public class DefinitionController : Controller
	{
		IDefinitionerOfPermissionByHttpContext _definitionerOfPermission;
		IGetterCanvas _getterCanvas;
		IGetterVersionProject _getterVersion;
		
		public DefinitionController(IDefinitionerOfPermissionByHttpContext definitionerOfPermission,
									IGetterCanvas getterCanvas,
									IGetterVersionProject getterVersion) 
		{
			_definitionerOfPermission = definitionerOfPermission;
			_getterCanvas = getterCanvas;
			_getterVersion = getterVersion;
		}

		[HttpGet("canvas/{canvasId}")]
		public async Task<IActionResult> GetPermissionCanvas(int canvasId)
		{
			CanvasResult canvasResult = await _getterCanvas.GetAsync(canvasId);
			return Ok(await _definitionerOfPermission.GetPermissionResult(canvasResult));
		}

		[HttpGet("version-project/{versionId}")]
		public async Task<IActionResult> GetPermissionVersionProject(int versionId)
		{
			VersionProjectResult versionProject = await _getterVersion.GetVersionProjectByIdAsync(versionId);
			return Ok(await _definitionerOfPermission.GetPermissionResult(versionProject));
		}
	}
}
