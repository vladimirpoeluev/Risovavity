using System.Security.Claims;

namespace Logic.JwtBearerAuthentication.Interface
{
    public interface ICreaterToken
    {
        string GenerateToken();
        List<Claim> Claims { get; set; }
    }
}
