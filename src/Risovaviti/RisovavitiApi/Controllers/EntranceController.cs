using Logic;
using Logic.Integration;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntranceController : ControllerBase
    {
        [HttpGet("input")]
        public ActionResult<Guid> Authorization(string login, string password)
        {
            try
            {
                return Ok(new Entrance().EntranceInSystem(login, password));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
