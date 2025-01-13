using Logic.Integration;
using DomainModel.Model;
using Logic.Interface;
using Logic.HashPassword;
using DomainModel.Integration;

namespace Logic
{
    public class Entrance : IEntrance
    {
        IInputerSystem _inputerSystem;
        IGeneraterHash _generaterHash;
        IRuleIntegrationUser userInt;
        public Entrance(IInputerSystem inputer, IRuleIntegrationUser integrationUser) 
        {
            _generaterHash = new GeneraterHash();
            _inputerSystem = inputer;
            userInt = integrationUser;
        }

        public string EntranceInSystem(string login, string password)
        {
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
