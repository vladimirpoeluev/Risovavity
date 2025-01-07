using DomainModel.ResultsRequest;

namespace Logic.JwtBearerAuthentication.Interface
{
    public interface IAdderSession
    {
        (string token, string refreshToken) GenerateSession(UserResult user);
    }
}