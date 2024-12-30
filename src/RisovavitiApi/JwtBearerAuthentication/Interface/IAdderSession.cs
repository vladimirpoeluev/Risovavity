using DomainModel.ResultsRequest;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IAdderSession
    {
        (string token, string refreshToken) GenerateSession(UserResult user);
    }
}