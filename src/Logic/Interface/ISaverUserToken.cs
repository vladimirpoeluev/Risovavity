using DomainModel.Model;

namespace Logic.Interface
{
    public interface ISaverUserToken
    {
        public User Get(Guid token);
        public void Add(User user, Guid token);

    }
}
