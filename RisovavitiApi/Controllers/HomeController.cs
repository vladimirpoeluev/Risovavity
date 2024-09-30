using Microsoft.AspNetCore.Mvc;
using Logic.Interface;
using DomainModel.ResultsRequest;
using Microsoft.AspNetCore.Authorization;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
		IGetUser _getUser;

        public HomeController(IGetUser getUser)
        {
			_getUser = getUser;
        }

        [HttpGet("getuser")]
        public IActionResult GetUser(int id)
        {
            try
            {
                return Ok(UserFullResult.CreateResultFromUser(_getUser.Get(id)));
            }
            catch
            {
                return ResultNotFound();
            }
        }

        private IActionResult ResultNotFound()
        {
			return NotFound(new Exception("Пользователь не найден или что то пошло не так"));
		}

        [HttpGet("getallusers")]
        public IActionResult GetUsers()
        {
            return Ok(_getUser.Get());
        }
    }
}
