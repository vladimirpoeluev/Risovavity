using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Error;
using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Logic.JwtBearerAuthentication.Interface;
using DomainModel.JwtModels;
using System.Security.Claims;
using Logic.EmailIntegration.Interface;
using DataIntegration.Interface.InterfaceOfModel;
using RisovavitiApi.UserOperate;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoController : Controller
    {
        IAutorizeServiceRefresh _autorizeServiceRefresh;
        IUserConfirmation _userConfirmation;
        IEntranceUser _entrance;
        IUserDataBase _userDataBase;

        public AutoController(  IAutorizeServiceRefresh authorize, 
                                IEntranceUser entrance, 
                                IUserConfirmation userConfirmation, 
                                IUserDataBase userData)
        {
            _autorizeServiceRefresh = authorize;
            _entrance = entrance;
            _userConfirmation = userConfirmation;
            _userDataBase = userData;
        }

        [HttpPost("regist")]
        public async Task<IActionResult> Regist([FromBody] AuthenticationForm form) 
        {
			try
			{
                User user = await _userDataBase.Users.FirstAsync(e => e.Login == form.Login);
                if(!user.UseTwoFactorAuthentication ?? true)
                {
                    return Ok(await _autorizeServiceRefresh.RegistSession(await _entrance.Login(form)));
                }
                await _userConfirmation.AddToPendingConfirmation(form);
				return Ok();
			}
			catch (Exception ex)
			{
				return NotFound(new ErrorMessageRequest() { Message = ex.Message + ex + ex.Source + ex.HelpLink, NumberError = 40 });
			}
		}

        [HttpGet("access")]
		[Authorize(AuthenticationSchemes = "refresh")]
		public async Task<IActionResult> Accert()
        {
            try
            {
                string refresh = HttpContext.User.Claims
                .Where((e) => e.Type == ClaimTypes.AuthenticationInstant)
                .First().Value;
                return Ok(await _autorizeServiceRefresh.ExtendSession(refresh));
            }
            catch (Exception) 
            {
                return BadRequest();
            }
            
        }
    }
}
