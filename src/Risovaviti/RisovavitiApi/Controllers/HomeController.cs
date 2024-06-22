using Microsoft.AspNetCore.Mvc;
using Logic.Integration;
using DomainModel.Records;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpPost("getuser")]
        public User GetUser(int id)
        {

            return IntegrationUser.GetUser(id);


        }
    }
}
