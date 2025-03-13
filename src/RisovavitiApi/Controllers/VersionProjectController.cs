using DomainModel.Exceptions;
using DomainModel.Integration;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using Logic;
using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.Model.Interfaces;
using RisovavitiApi.UserOperate;

namespace RisovavitiApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class VersionProjectController : Controller
	{
		IFabricOperateVersionProject _operate;
		IBuilderGetterVerionsByParent _builder;
		IEditVersionProject _editVersionProject;
		IDefinitionerOfPermissionByHttpContext _definitionerOfPermission;
		ILikesOfVersitonService _likesService;
		IRuleIntegrationUser _integrationUser;
		IGetterWorkByAuthorId _getterWorkByAuthorId;

		public VersionProjectController(IFabricOperateVersionProject operate, 
										IBuilderGetterVerionsByParent getterVerionsByParent,
										IEditVersionProject editVersion,
										IDefinitionerOfPermissionByHttpContext definitionerOfPermission,
										ILikesOfVersitonService likes,
										IRuleIntegrationUser integrationUser,
										IGetterWorkByAuthorId getterWorkByAuthor) 
		{
			_operate = operate;
			_builder = getterVerionsByParent;
			_editVersionProject = editVersion;
			_definitionerOfPermission = definitionerOfPermission;
			_likesService = likes;
			_integrationUser = integrationUser;
			_getterWorkByAuthorId = getterWorkByAuthor;
		}

		[HttpGet("get/by-auhtorid/{id}")]
		public async Task<IActionResult> GetByAuthor(int id, int skip, int take)
		{
			return Ok(await _getterWorkByAuthorId.GetVersionProjectResultsByAuthorId(id, skip, take));
		}

		[HttpGet("islike/{idVersion}")]
		public async Task<IActionResult> IsLike(int idVersion)
		{
			return Ok(await _likesService.IsLike(idVersion));
		}

		[HttpGet("couint-likes/{idVersion}")]
		public async Task<IActionResult> GetCointLikes(int idVersion)
		{
			return Ok(await _likesService.CouintLikes(idVersion));
		}

		[HttpPost("like/{idVersion}")]
		public async Task<IActionResult> GiveLike(int idVersion)
		{
			await _likesService.Like(idVersion);
			return Ok();
		}

		[HttpPost("unlike/{idVersion}")]
		public async Task<IActionResult> TakeAwatALike(int idVersion)
		{
			await _likesService.UnLike(idVersion);
			return Ok();
		}

		[HttpGet("get/{id}")]
		public async Task<IActionResult> Get(int id) 
		{
			try
			{
				return await TryGetById(id);
			}
			catch (NotPermissionExeption)
			{
				return Unauthorized();
			}
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}

		async Task<OkObjectResult> TryGetById(int id) 
		{
			var getter = _operate.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser));
			var vertion = await getter.GetVersionProjectByIdAsync(id);
			PermissionResult permissionResult = await _definitionerOfPermission.GetPermissionResult(vertion);
			if(!permissionResult.Read ?? false)
			{
				throw new NotPermissionExeption();
			}
			return Ok(vertion);
		}

		[HttpGet("get")]
		public async Task<IActionResult> Get(int skip, int take)
		{
			var getter = _operate.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser));
			var versions = await getter.GetVersionProjectsAsync(skip, take);
			return Ok(versions);
		}

		[HttpGet("get/versions/{id}")]
		public async Task<IActionResult> GetVersion(int id, int skip, int take)
		{
			VersionProjectResult project = await _operate
				.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser))
				.GetVersionProjectByIdAsync(id);
			IEnumerable<VersionProjectResult> result = await _builder.Skip(skip)
				.Take(take).ToGetter()
				.GetVersionsByParent(project);
			return Ok(result);
		}

		[HttpPost("add")]
		public async Task<IActionResult> Add([FromBody] VersionProjectForAddResult result)
		{
			var adder = _operate.CreateAdder(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser));
			await adder.AddVertionProjectAsync(result);
			return Ok();
		}

		[HttpPost("edit")]
		public async Task<IActionResult> Edit([FromBody] VerstionProjectEditResutl newVerstion)
		{
			var getter = _operate.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser));
			var vertion = await getter.GetVersionProjectByIdAsync(newVerstion.VerstionId);
			PermissionResult permission = await _definitionerOfPermission.GetPermissionResult(vertion);
			if(!permission.Edit ?? false)
			{
				return Unauthorized();
			}
			await _editVersionProject.Edit(newVerstion);
			return Ok();
		}

		[HttpPost("delet/{id}")]
		public async Task<IActionResult> Delet(int id)
		{
			var getter = _operate.CreateGetter(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser));
			var vertion = await getter.GetVersionProjectByIdAsync(id);
			PermissionResult permission = await _definitionerOfPermission.GetPermissionResult(vertion);
			if (!permission.Edit ?? false)
			{
				return Unauthorized();
			}
			var adder = _operate.CreateAdder(UserGetterByContext.GetUserIntegration(HttpContext, _integrationUser));
			await adder.DeleteVertionProjectAsync(id);
			return Ok();
		}

		
	}
}
