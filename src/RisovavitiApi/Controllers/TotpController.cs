using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.Integration.TotpOperation;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.TotpModels;
using Logic;
using Logic.ToptOperation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RisovavitiApi.UserOperate;
using System.Security;
using System.Security.Claims;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/restore-access")]
    public class TotpController : Controller
    {
        IVerifycaterTotp verifycaterTotp;
        ITotpGetter totpGetter;
        IRuleIntegrationUser ruleIntegration;
        DatabaseContext database;
        IPasswordEditer passwordEditer;

        public TotpController(ITotpGetter getter, IVerifycaterTotp verifycater, 
            IRuleIntegrationUser integrationUser,
            DatabaseContext context,
            IPasswordEditer passwordEditer) 
        {
            verifycaterTotp = verifycater;
            ruleIntegration = integrationUser;
            totpGetter = getter;
            database = context;
            this.passwordEditer = passwordEditer;
        }

        [HttpGet("key")]
        [Authorize]
        public async Task<ActionResult<TotpKeysResult>> GetRestore()
        {
            return Ok(await totpGetter.CreateKeyAsync(UserGetterByContext.GetUserIntegration(HttpContext,ruleIntegration).Id));
        }

        [HttpPost("edit-password")]
        [Authorize(AuthenticationSchemes = "restore")]
        public async Task<IActionResult> EditPassword(EditNewPasswordResul editPassword)
        {
            UserResult user = UserGetterByContext.GetUserIntegration(HttpContext, ruleIntegration);
            int id = user.Id;
			passwordEditer.User = new User() { Id = id };
			await passwordEditer.PasswordEditAsync(editPassword);
            return Ok();
        }

        [HttpPost("restore")]
        public async Task<IActionResult> Restore(CodeToptConfirmationResult restoreAccess)
        {
            int? id = await database.Users.Where(user => user.Login == restoreAccess.Login).Select(user => user.Id).FirstOrDefaultAsync();
            var creater = new CreaterTokenForRestore();
            var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Sid, (id ?? 0).ToString())
			};
            creater.Claims = claims;
            if(await verifycaterTotp.VerifycaterTotpAsync(id ?? 0, restoreAccess.TotpCode))
            {
                return Ok(creater.GenerateToken());
            }
            return BadRequest();
        }



	}
}
