using Logic.Integration;

namespace Logic
{
    public class Entrance
    {
        public Guid EntranceInSystem(string login, string password)
        {
            var userInt = new IntegrationUser();
            var users = userInt.Get(login, password);
            if (users.Length == 1)
            {
                User user = users[0];
                return Guid.NewGuid();
            }
            throw new Exception("Login or password was entered incorrectly");
        }
    }
}
