using DomainModel.Model;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.TotpModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/restore-access")]
    public class TotpController : Controller
    {
        public TotpController() { }

        [HttpGet("key")]
        [Authorize]
        public async Task<ActionResult<TotpKeysResult>> GetRestore()
        {
            throw new NotImplementedException();
        }

        [HttpPost("edit-password")]
        [Authorize(AuthenticationSchemes = "restore")]
        public async Task<IActionResult> EditPassword(EditPasswordResult editPassword)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Restore(TotpRestoreAccess restoreAccess)
        {
            throw new NotImplementedException();
        }



	}
}
