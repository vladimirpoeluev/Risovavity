using Logic.Integration;
using DomainModel.Model;
using Logic.Interface;

namespace Logic
{
    public class Entrance : IEntrance
    {
        IInputerSystem _inputerSystem;
        public Entrance(IInputerSystem inputer) 
        {
            _inputerSystem = inputer;
        }

        public string EntranceInSystem(string login, string password)
        {
            var userInt = new IntegrationUsersEf();
            var users = userInt.Get(login, password);
            if (users.Length == 1)
            {
                User user = users[0];

                return _inputerSystem.InputUser(user);
            }
            throw new Exception("Login or password was entered incorrectly");
        }

        public async Task<string> EntranceInSystemAsync(string login, string password)
        {

            var retult = await Task.Run<string>(() =>
            {
                try
                {
                    return EntranceInSystem(login, password);
				}
                catch
                {
                    return String.Empty;
                }
            });
            if(retult == String.Empty)
            {
                throw new Exception("Logoin or password was enterad incorrectly");
            }
            return retult;

        }
    }
}
