using DomainModel.Model;

namespace InteractiveApiRisovaviti.Interface
{
    internal interface IEntrance
    {
        Role IputSystem(string login, string password);
    }
}
