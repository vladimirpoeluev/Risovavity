using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface ICreaterToken
    {
        string GenerateToken();
        List<Claim> Claims { get; set; }
    }
}
