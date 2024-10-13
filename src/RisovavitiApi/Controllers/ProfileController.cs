using Logic.Interface;
using Logic;
using Microsoft.AspNetCore.Mvc;
using DomainModel.ResultsRequest;
using DomainModel.Model;
using DomainModel.Integration;
using Microsoft.AspNetCore.Authorization;
using DomainModel.ResultsRequest.Error;
using System.Security.Claims;

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
			User user = GetUserIntegration();
			var result = UserResult.CreateResultFromUser(user);
			return Ok(result);
		}

		private User GetUserIntegration()
		{
			int id = int.Parse(HttpContext.User.Claims
							.Where((claim) => claim.Type == ClaimTypes.Sid)
							.First().Value);
			return _integrationUser.Get(id);
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

		[HttpPost("setprofile")]
		public IActionResult SetUser([FromBody] UserResult user)
		{
			try
			{
				User userOld = GetUserIntegration();
				_integrationUser.Update(userOld, new User()
				{
					Password = userOld.Password,
					Login = userOld.Login,
					Email = user.Email,
					Role = userOld.Role,
					Id = user.Id,
					IdRole = userOld.IdRole,
					Name = user.Name,
				});
				return Ok();
			}
			catch (Exception ex) 
			{
				return BadRequest(new ErrorMessageRequest()
				{
					Message = ex.Message,
					NumberError = 10
				});
			}
			
		}
	}
}
