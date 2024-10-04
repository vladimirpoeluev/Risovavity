using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using RisovavitiApi.JwtBearerAuthentication;
using DomainModel.ResultsRequest.Error;

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


        [HttpGet("input")]
        public async Task<ActionResult<string>> AuthorizationSystem(string login, string password)
        {
            try
            {
                string token = await entrance.EntranceInSystemAsync(login, password);
				return Ok(token);
            }
            catch(Exception ex)
            {
                return NotFound(new ErrorMessageRequest() { Message = ex.Message, NumberError = 40});
            }
        }

	}
}
