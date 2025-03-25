using DomainModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
    [Route("api/liked")]
    [ApiController]
    [Authorize]
    public class LikeWorksController : Controller
    {
        IGetterWorksByLikes _getterWorksByLikes;
        public LikeWorksController(IGetterWorksByLikes getterWorksByLikes) 
        {
            _getterWorksByLikes = getterWorksByLikes;
        }

        [HttpGet("canvas/{userId}")]
        public async Task<IActionResult> GetCanvas(int userId, [FromQuery]RangeTakeAndSkip range) 
        {
            IEnumerable<CanvasResult> canvases = await _getterWorksByLikes.GetCanvas(userId, range);
            return Ok(canvases);
        }

		[HttpGet("version/{userId}")]
		public async Task<IActionResult> GetVersion(int userId, [FromQuery]RangeTakeAndSkip range)
		{
			IEnumerable<VersionProjectResult> versions = await _getterWorksByLikes.GetVersionProject(userId, range);
			return Ok(versions);
		}
	}
}
