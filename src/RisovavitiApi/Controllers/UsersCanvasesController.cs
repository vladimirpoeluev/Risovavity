using Microsoft.AspNetCore.Mvc;
using Logic.Interface;
using RisovavitiApi.UserOperate;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.AspNetCore.Authorization;
using DomainModel.Integration.CanvasOperation;
using RisovavitiApi.Model.Interfaces;
using DomainModel.Exceptions;
using DomainModel.ResultsRequest;
using DomainModel.Model;
using StackExchange.Redis;

namespace RisovavitiApi.Controllers
{
    [ApiController]
	[Route("api/canvas")]
	[Authorize]
	public class UsersCanvasesController : Controller
	{
		IFabricCanvasOperation _fabricCanvasOperation;
		IEditMainVerstionInCanvas _editMainVersiton;
		IDefinitionerOfPermissionByHttpContext _definitionerOfPermission;

		public UsersCanvasesController(	IFabricCanvasOperation fabricOperate, 
										IEditMainVerstionInCanvas editMain,
										IDefinitionerOfPermissionByHttpContext definitionerOfPermission) 
		{
			_fabricCanvasOperation = fabricOperate;
			_editMainVersiton = editMain;	
			_definitionerOfPermission = definitionerOfPermission;
		}

		[HttpGet("get")]
		public async Task<IActionResult> Get(int skip, int take)
		{
			var getter = _fabricCanvasOperation.CreateGetterCanvas(UserGetterByContext.GetUserIntegration(HttpContext));

			var canvases = await getter.GetAsync(skip, take);
			return Ok(canvases);
		}

		[HttpGet("get/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				return await TryGetCanvasById(id);
			}
			catch (NotPermissionExeption)
			{
				return Unauthorized();
			}
			catch (InvalidOperationException)
			{
				return NotFound(new CanvasResult());
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

		async Task<OkObjectResult> TryGetCanvasById(int id)
		{
			var getter = _fabricCanvasOperation.CreateGetterCanvas(UserGetterByContext.GetUserIntegration(HttpContext));
			var canvas = await getter.GetAsync(id);
			PermissionResult permission = await _definitionerOfPermission.GetPermissionResult(canvas);
			if (permission.Read ?? false)
			{
				return Ok(canvas);
			}
			else
			{
				throw new NotPermissionExeption();
			}
			
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody] CanvasAddResult result)
		{
			var adder = _fabricCanvasOperation.CreateAdderCanvas(UserGetterByContext.GetUserIntegration(HttpContext));
			await adder.AddCanvas(result);
			return Ok();
		}

		[HttpPost("delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			
			try
			{
				var getter = _fabricCanvasOperation.CreateGetterCanvas(UserGetterByContext.GetUserIntegration(HttpContext));
				var editer = _fabricCanvasOperation.CreateEditerCanvas(UserGetterByContext.GetUserIntegration(HttpContext));

				var canvas = await getter.GetAsync(id);
				PermissionResult permissions = await _definitionerOfPermission.GetPermissionResult(canvas);
				if (!permissions.Edit ?? false)
				{
					return Unauthorized();
				}
				editer.UpdateCanvas(new CanvasEditerResult()
				{
					Id = canvas.Id,
					Title = canvas.Name,
					Description = canvas.Description,
					VersionProjectId = canvas.VersionId,
					StatusId = 4
				});

				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost("edit/mainVersion")]
		public async Task<IActionResult> EditMainVerstion([FromBody] MainVersionInCanvasResutl editResult)
		{
			var getter = _fabricCanvasOperation.CreateGetterCanvas(UserGetterByContext.GetUserIntegration(HttpContext));
			var canvas = await getter.GetAsync(editResult.CanvasId);
			PermissionResult permissions = await _definitionerOfPermission.GetPermissionResult(canvas);
			if (!permissions.Edit ?? false)
			{
				return Unauthorized();
			}
			await _editMainVersiton.SelectMainVerstion(editResult);
			return Ok();
		}

		[HttpPost("edit/{id}")]
		public async Task<IActionResult> EditCanvas(int id, [FromBody] CanvasEditerResult newCanvas)
		{
			var getter = _fabricCanvasOperation.CreateGetterCanvas(UserGetterByContext.GetUserIntegration(HttpContext));
			var canvas = await getter.GetAsync(id);
			PermissionResult permissions = await _definitionerOfPermission.GetPermissionResult(canvas);
			if (!permissions.Edit ?? false)
			{
				return Unauthorized();
			}
			try
			{
				return TryEditCanvas(id, newCanvas);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		OkResult TryEditCanvas(int id, CanvasEditerResult newCanvas)
		{
			var editer = _fabricCanvasOperation.CreateEditerCanvas(UserGetterByContext.GetUserIntegration(HttpContext));
			newCanvas.Id = id;
			editer.UpdateCanvas(newCanvas);
			return Ok();
		}
	}
}
