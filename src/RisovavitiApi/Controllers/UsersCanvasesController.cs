using Microsoft.AspNetCore.Mvc;
using Logic.Interface;
using DomainModel.Model;
using DomainModel.InputRecords;

namespace RisovavitiApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class UsersCanvasesController : Controller
	{
		private ICreateSaverToken _createToken;
		private IGetCanvasAsync _getCanvas;

		public UsersCanvasesController(ICreateSaverToken createSaver, IGetCanvasAsync getCanvas) 
		{
			_createToken = createSaver;
			_getCanvas = getCanvas;
		}

		private bool CheckAuthorization(Guid guid)
		{
			try
			{
				_createToken.CreateSaver().Get(guid);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
			
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CanvasTitle>>> Get(Guid guid) 
		{
			if(CheckAuthorization(guid))
				return NotFound();
			IEnumerable<Canvas> canvases = await _getCanvas.GetAsync();
			List<CanvasTitle> result = new List<CanvasTitle>();

			await Task.Run(() =>
			{
				foreach (var canvas in canvases)
				{
					result.Add(new CanvasTitle()
					{
						Name = canvas.Name,
						IdAuthorNavigation = canvas.IdAuthorNavigation,
						IdStatusNavigation = canvas.IdStatusNavigation,
						Description = canvas.Description ?? String.Empty,
					});
				}
			});
			return Ok(result);

		}
	}
}
