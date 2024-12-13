using DomainModel.ResultsRequest;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IAdderSessionByRefresh
    {
        string AddSession(UserResult user, string descrition);
    }
}
