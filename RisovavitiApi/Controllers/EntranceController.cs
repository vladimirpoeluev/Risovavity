using Logic.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Guid>> Authorization(string login, string password)
        {
            try
            {
                Guid id = await entrance.EntranceInSystemAsync(login, password);
				return Ok(id);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
