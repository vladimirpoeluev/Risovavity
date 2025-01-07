using DomainModel.JwtModels;
using DomainModel.ResultsRequest.EmailResult;
using Logic.EmailIntegration.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class EmailController : Controller
	{

		IEmailConfirmaion _emailConfirmaion;
		IUserConfirmation _userConfirmation;
		public EmailController(	IEmailConfirmaion emailConfirmaion, 
								IUserConfirmation userConfirmation)
		{
			_emailConfirmaion = emailConfirmaion;
			_userConfirmation = userConfirmation;
		}

		[HttpPost("confirmation")]
		public async Task<IActionResult> EmailСonfirmation([FromBody] EmailConfirmaionResult confirmaion)
		{
			await _emailConfirmaion.Valid(confirmaion);
			return Ok();
		}

		[HttpPost("userconfimation")]
		public async Task<IActionResult> UserConfirmation([FromBody]UserConfirmationResult confirmation)
		{
			TokensRefreshAndAccess tokens = await _userConfirmation.Verify(confirmation);
			return Ok(tokens);
		}
	}
}
