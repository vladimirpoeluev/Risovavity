using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.ComponentModel;

namespace RisovavitiApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class ImageProjectController : Controller
	{
		IGetterImageProject _getterImage;
		public ImageProjectController(IGetterImageProject getterImage) 
		{
			_getterImage = getterImage;
		}

		[HttpGet("get/{id}")]
		public async Task<IActionResult> Get(int id) 
		{
			return await TryGetImage(id);
		}

		async Task<IActionResult> TryGetImage(int id)
		{
			try
			{
				ImageResult result = await _getterImage.GetImageResult(id);
				return Ok(result);
			}
			catch
			{
				return NotFound();
			}
			
		}

	}
}
