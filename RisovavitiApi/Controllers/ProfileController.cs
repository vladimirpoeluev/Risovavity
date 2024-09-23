using Logic.Interface;
using Logic;
using Microsoft.AspNetCore.Mvc;
using DomainModel.ResultsRequest;
using DomainModel.Model;
using DomainModel.Integration;

namespace RisovavitiApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfileController : Controller
	{
		private ICreateSaverToken _createSaver;
		private IRuleIntegrationUser _integrationUser;

		public ProfileController(ICreateSaverToken create, IRuleIntegrationUser integrationUser) 
		{
			_createSaver = create;
			_integrationUser = integrationUser;
		}

		[HttpGet()]
		public ActionResult<UserResult> GetUser(Guid guid)
		{
			var user = _createSaver.CreateSaver().Get(guid);
			var userResult = new UserResult()
			{
				Id = user?.Id ?? 0,
				Name = user?.Name ?? "Отсутствует",
				Email = user?.Email ?? "Отсутствует",
				IdRoleNavigation = RoleResult.CreateRoleResultFromRole(user.Role)
			};
			return Ok(userResult);
		}

		[HttpGet("getimage")]
		public ActionResult<byte[]> GetImage(Guid guid)
		{
			var user = _createSaver.CreateSaver().Get(guid);

			return Ok(user.Icon);
		}

		[HttpPost("setimage")]
		public ActionResult<IFormFile> SetImage(Guid guid, IFormFile image)
		{
			using (var reader = new StreamReader(image.OpenReadStream()))
			{
				string a = reader.ReadToEnd();
				return Ok(image);
			}
		}

		[HttpPost("setuser")]
		public ActionResult<User> SetUser(Guid guid, UserResult user)
		{
			return Ok(user);
		}
	}
}
