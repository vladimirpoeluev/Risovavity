using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Error;
using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using RisovavitiApi.Model;
using System.Security.Claims;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoController : Controller
    {
        IAutorizeServiceRefresh _autorizeServiceRefresh;
        IEntranceUser _entrance;

        public AutoController(IAutorizeServiceRefresh authorize, IEntranceUser entrance)
        {
            _autorizeServiceRefresh = authorize;
            _entrance = entrance;
        }

        [HttpPost("regist")]
        public async Task<IActionResult> Regist([FromBody] AuthenticationForm form) 
        {
			try
			{
                TokensRefreshAndAccess tokens = await _autorizeServiceRefresh.RegistSession(
                    await _entrance.Login(form));

				return Ok(tokens);
			}
			catch (Exception ex)
			{
				return NotFound(new ErrorMessageRequest() { Message = ex.Message, NumberError = 40 });
			}
		}

        [HttpGet("access")]
		[Authorize(AuthenticationSchemes = "refresh")]
		public IActionResult Accert()
        {
            string refresh = HttpContext.User.Claims
                .Where((e) => e.Type == ClaimTypes.AuthenticationInstant)
                .First().Value;
            return Ok(_autorizeServiceRefresh.ExtendSession(refresh));
        }
    }
}
