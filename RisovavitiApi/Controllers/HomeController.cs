using Microsoft.AspNetCore.Mvc;
using Logic.Integration;
using DomainModel.Model;
using DomainModel.Integration;
using Logic.Interface;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
