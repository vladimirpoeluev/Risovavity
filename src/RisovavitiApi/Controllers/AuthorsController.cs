using DomainModel.Integration;
using DomainModel.ResultsRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{

	[Authorize]
	[Route("api/[conroller]")]
	[ApiController]
	public class AuthorsController : Controller
	{
		IAuthorResultGetter AuthorResultGetter { get; set; }

		public AuthorsController(IAuthorResultGetter authorResultGetter)
		{
			AuthorResultGetter = authorResultGetter;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IEnumerable<AuthorResult> authors = await AuthorResultGetter.GetAuthors();
			return Ok(authors);
		}

		[HttpPost]
		public async Task<IActionResult> GetByName([FromBody] string name)
		{
			IEnumerable<AuthorResult> authors = await AuthorResultGetter.GetAuthorsByName(name);
			return Ok(authors);
		}

		[HttpGet]
		public IActionResult Get(int id)
		{
			return NotFound();
		}
	}
}
