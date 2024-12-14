namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IGetterSessionByRefresh
    {
        Task<SessionAuthorizeObject> GetSessionAsync(string refresh);
        SessionAuthorizeObject GetSession(string refresh);
    }
}
