using DomainModel.Integration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class AvatarUsersController : Controller
	{
		IUserAvatarGetter _avatarGetter;
		public AvatarUsersController(IUserAvatarGetter avatarGetter) 
		{
			_avatarGetter = avatarGetter;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int id) 
			=> Ok(await _avatarGetter.GetAvatarUserAsync(id));
	}
}
