using DomainModel.ResultsRequest;

namespace Logic.JwtBearerAuthentication.Interface
{
    public interface IAdderSessionByRefresh
    {
		Guid Refresh { get; set; }
		Task<string> AddSession(SessionAuthorizeObject obj);
    }
}
