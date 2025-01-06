using DomainModel.ResultsRequest.EmailResult;
using Logic.EmailIntegration;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmailController : Controller
	{

		EmailConfirmaion _emailConfirmaion;
		public EmailController(EmailConfirmaion emailConfirmaion)
		{
			_emailConfirmaion = emailConfirmaion;
		}

		[HttpPost("confirmation")]
		public async Task<IActionResult> EmailСonfirmation([FromBody] EmailConfirmaionResult confirmaion)
		{
			await _emailConfirmaion.Valid(confirmaion);
			return Ok();
		}

		[HttpGet("userconfimation")]
		public IActionResult UserConfirmation([FromBody]string code)
		{
			return View();
		}
	}
}
