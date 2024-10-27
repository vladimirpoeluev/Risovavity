using Logic.Integration;
using DomainModel.Model;
using Logic.Interface;
using Logic.HashPassword;

namespace Logic
{
    public class Entrance : IEntrance
    {
        IInputerSystem _inputerSystem;
        IGeneraterHash _generaterHash;
        public Entrance(IInputerSystem inputer) 
        {
            _generaterHash = new GeneraterHash();
            _inputerSystem = inputer;
        }

        public string EntranceInSystem(string login, string password)
        {
            var userInt = new IntegrationUsersEf();
            var users = userInt.Get(login);
            if (users.Length == 1)
            {
                User user = users[0];
                VerifiPassword(password, user.Password);
                return _inputerSystem.InputUser(user);
            }
            throw new Exception("Login or password was entered incorrectly");
        }

        public void VerifiPassword(string password, string passwordHash)
        {
			if(!_generaterHash.Verify(password, passwordHash))
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
