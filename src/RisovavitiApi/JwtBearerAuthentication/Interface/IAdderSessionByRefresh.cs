namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
    public interface IAdderSessionByRefresh
    {
        string AddSession(int UserId, string Descrition);
    }
}
