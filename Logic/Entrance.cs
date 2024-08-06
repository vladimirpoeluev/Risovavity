using Logic.Integration;
using DomainModel.Model;
using Logic.Interface;

namespace Logic
{
    public class Entrance : IEntrance
    {
        public Guid EntranceInSystem(string login, string password)
        {
            var userInt = new IntegrationUsersEf();
            var users = userInt.Get(login, password);
            if (users.Length == 1)
            {
                User user = users[0];
                Guid guid = Guid.NewGuid();
                var role = user.Role;
                SingleSaveUserToken singleSaveUserToken = new SingleSaveUserToken();
                var saver = singleSaveUserToken.CreateSaver();
                saver.Add(user, guid);

                return guid;
            }
            throw new Exception("Login or password was entered incorrectly");
        }

        public async Task<Guid> EntranceInSystemAsync(string login, string password)
        {

            var retult = await Task.Run<Guid>(() =>
            {
                try
                {
                    return EntranceInSystem(login, password);
				}
                catch
                {
                    return Guid.Empty;
                }
            });
            if(retult == Guid.Empty)
            {
                throw new Exception("Logoin or password was enterad incorrectly");
            }
            return retult;

        }
    }
}
