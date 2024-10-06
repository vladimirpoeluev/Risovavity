using Logic.Interface;
using Logic;
using Microsoft.AspNetCore.Mvc;
using DomainModel.ResultsRequest;
using DomainModel.Model;
using DomainModel.Integration;
using Microsoft.AspNetCore.Authorization;

namespace RisovavitiApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProfileController : Controller
	{
		private IRuleIntegrationUser _integrationUser;

		public ProfileController(IRuleIntegrationUser integrationUser) 
		{
			_integrationUser = integrationUser;
		}

		[HttpGet()]
		public ActionResult<UserResult> GetUser()
		{
			User user = _integrationUser.Get(new UserNameFilter(HttpContext.User.Identity?.Name ?? string.Empty));
			var result = UserResult.CreateResultFromUser(user);
			return Ok(result);
		}

		[HttpGet("getimage")]
		public ActionResult<byte[]> GetImage()
		{

			return Ok();
		}

		[HttpPost("setimage")]
		public ActionResult<IFormFile> SetImage(IFormFile image)
		{
			using (var reader = new StreamReader(image.OpenReadStream()))
			{ 
				string a = reader.ReadToEnd();
				return Ok(a);
			}
		}

		[HttpPost("setuser")]
		public ActionResult<User> SetUser(UserResult user)
		{
			return Ok(user);
		}
	}
}
