using DomainModel.ResultsRequest;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IAdderSessionByRefresh
    {
        Task<string> AddSession(SessionAuthorizeObject obj);
    }
}
