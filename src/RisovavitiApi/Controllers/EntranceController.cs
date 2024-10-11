using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using DomainModel.ResultsRequest.Error;
using DomainModel.ResultsRequest;

namespace RisovavitiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        private IEntrance entrance;

        public EntranceController(IEntrance entrance)
        {
            this.entrance = entrance;
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
	}
}
