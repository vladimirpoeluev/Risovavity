namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IGetterSessionByRefresh
    {
        (int, string) GetSession(string refresh);
    }
}
