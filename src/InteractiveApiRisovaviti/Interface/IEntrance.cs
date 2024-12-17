

namespace InteractiveApiRisovaviti.Interface
{
    public interface IEntrance
    {
        IAuthenticationUser IputSystem(string login, string password);
        Task<IAuthenticationUser> InputSystemAsync(string login, string password);
    }
}
