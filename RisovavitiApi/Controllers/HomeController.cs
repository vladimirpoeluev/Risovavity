using Microsoft.AspNetCore.Mvc;
using Logic.Integration;
using DomainModel.Model;
using DomainModel.Integration;
using Logic.Interface;
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

        [HttpPost("getuser")]
        public User GetUser(int id)
        {
            return _getUser.Get(id);
        }
    }
}
