using Microsoft.AspNetCore.Mvc;
using Logic.Interface;
using RisovavitiApi.UserOperate;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RisovavitiApi.Controllers
{
    [ApiController]
	[Route("api/canvas")]
	[Authorize]
	public class UsersCanvasesController : Controller
	{
		IFabricCanvasOperation _fabricCanvasOperation;

		public UsersCanvasesController(IFabricCanvasOperation fabricOperate) 
		{
			_fabricCanvasOperation = fabricOperate;
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
			return Ok(canvas);
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
			throw new NotImplementedException();
		}
	}
}
