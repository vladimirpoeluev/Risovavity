using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using DomainModel.ResultsRequest.Error;
using DomainModel.ResultsRequest;
using DomainModel.Model;

namespace RisovavitiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        private IEntrance entrance;
		private IRegistationUser registation;
        public EntranceController(IEntrance entrance, IRegistationUser registation)
        {
            this.entrance = entrance;
			this.registation = registation;
        }

		[HttpPost("input")]
		public async Task<ActionResult<string>> AuthorizationSystemPost([FromBody] AuthenticationForm form)
		{
			try
			{
				string token = await entrance.EntranceInSystemAsync(form.Login, form.Password);
				return Ok(token);
			}
			catch (Exception ex)
			{
				return NotFound(new ErrorMessageRequest() { Message = ex.Message, NumberError = 40 });
			}
		}

		[HttpPost("regist")]
		public IActionResult RegistrationSystem([FromBody] RegistrationForm user)
		{
			try
			{
				return TryRegistrationUser(user);
			}
			catch (Exception)
			{
				return ReturningRegistrationError();
			}
		}

		IActionResult TryRegistrationUser(RegistrationForm user) 
		{
			registation.RegistrationUser(user);
			return Ok();
		}

		IActionResult ReturningRegistrationError()
		{
			return BadRequest(new ErrorMessageRequest()
			{
				Message = "Не удалось зарегистрировать пользователя",
				NumberError = 100
			});
		}
	}
}
