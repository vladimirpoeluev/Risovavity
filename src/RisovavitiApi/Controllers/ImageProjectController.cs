using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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
			ImageResult result = await _getterImage.GetImageResult(id);
			return Ok(result);
		}

	}
}
