
using DomainModel.Model;

namespace DomainModel.Integration
{
    public interface IRuleIntegrationUser
    {
        bool Add(User canvas);
        bool Remove(User canvas);
        bool Update(User canvas, User newCanvas);
        User Get(int id);
        User[] Get();
        User[] Get(string login, string password);
    }
}
