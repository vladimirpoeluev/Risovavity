using DomainModel.ResultsRequest;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IAdderSessionByRefresh
    {
		Guid Refresh { get; set; }
		Task<string> AddSession(SessionAuthorizeObject obj);
    }
}
