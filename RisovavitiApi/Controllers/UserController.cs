using DomainModel.Model;
using Logic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IGetUser _getUser;
        ICreateSaverToken _createSaverToken;

        public UserController(IGetUser getUser, ICreateSaverToken createSaver) 
        {
            _getUser = getUser;
            _createSaverToken = createSaver;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<User>> GetUsers(Guid guid)
        {
            try
            {
				_createSaverToken.CreateSaver().Get(guid);
			}
            catch(Exception)
            {
                return new NotFoundResult();
            } 
            return Ok(_getUser.Get());
        }
    }
}
