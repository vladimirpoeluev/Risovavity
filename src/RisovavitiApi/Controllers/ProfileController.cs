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
		private IPasswordEditer _passwordEditer;

		public ProfileController(IRuleIntegrationUser integrationUser, IPasswordEditer passwordEditer) 
		{
			_integrationUser = integrationUser;
			_passwordEditer = passwordEditer;
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
		public ActionResult<UserAvatarResult> GetImage()
		{
			var user = GetUserIntegration();
			try
			{
				UserAvatarResult userAvatar = new()
				{
					UserName = user.Name,
					AvatarResult = user.Icon ?? throw new Exception("Нету фотографии профиля")
				};
				return Ok(userAvatar);
			}
			catch (Exception ex) 
			{
				return NotFound(new ErrorMessageRequest() { Message = ex.Message, NumberError = 20 });
			}
		}

		[HttpPost("setimage")]
		public IActionResult SetImage([FromBody]UserAvatarResult avatarResult)
		{
			var user = GetUserIntegration();
			var newUser = new User() 
			{
				Id = user.Id,
				Name = user.Name,
				Role = user.Role,
				IdRole = user.IdRole,
				Icon = avatarResult.AvatarResult,
				Email = user.Email,
				Password = user.Password,
				Login = user.Login,
			}; 

			_integrationUser.Update(user, newUser);

			return Ok();
		}

		[HttpPost("setprofile")]
		public IActionResult SetUser([FromBody] UserResult user)
		{
			try
			{
				User userOld = GetUserIntegration();
				_integrationUser.Update(userOld, new User()
				{
					Icon = userOld.Icon,
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

		[HttpPost("passwordEdit")]
		public async Task<IActionResult> PasswordEdit(EditPasswordResult passwordEdit)
		{
			try
			{
				return await TryPasswordEdit(passwordEdit);
			}
			catch (Exception) 
			{
				return ErrorPasswordEdit();
			}
		}

		async Task<OkResult> TryPasswordEdit(EditPasswordResult editPassword)
		{
			_passwordEditer.User = GetUserIntegration();
			await _passwordEditer.PasswordEditAsync(editPassword);
			return Ok();
		}

		BadRequestObjectResult ErrorPasswordEdit()
		{
			return BadRequest(new ErrorMessageRequest()
			{
				Message = "Ошибка изменения пароля",
				NumberError = 10
			});
		}
	}
}
