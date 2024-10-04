using DomainModel.Model;

namespace InteractiveApiRisovaviti.Interface
{
    internal interface IEntrance
    {
        IAuthenticationUser IputSystem(string login, string password);
    }
}
