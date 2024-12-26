
using DomainModel.ResultsRequest;

namespace RisovavitiApi.JwtBearerAuthentication.Interface;

public interface ISessionService
{
    Task<IEnumerable<SessionAuthorizeObject>> SessionAuthorizeObjectAsync(UserResult user);
    Task DeleteSessionAsync(string refresh);
    Task DeleteAllSesstionByUserAsync(string userId);
}
