using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Error;
using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using RisovavitiApi.Model;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "refresh")]
    public class AutoController : Controller
    {
        IAutorizeServiceRefresh _autorizeServiceRefresh;
        IEntrance _entrance;

        public AutoController(IAutorizeServiceRefresh authorize, IEntrance entrance)
        {
            _autorizeServiceRefresh = authorize;
            _entrance = entrance;
        }

        [HttpGet("regist")]
        public async IActionResult Regist([FromBody] AuthenticationForm form) 
        {
			try
			{
				await _entrance.EntranceInSystemAsync(form.Login, form.Password);
				return Ok();
			}
			catch (Exception ex)
			{
				return NotFound(new ErrorMessageRequest() { Message = ex.Message, NumberError = 40 });
			}
		}

        [HttpGet("access")]
        public IActionResult Accert()
        {
            return Ok(new TokensRefreshAndAccess("", ""));
        }
    }
}
