

using DataIntegration;
using DomainModel.Integration;

namespace Logic.Integration
{
    public class IntegrationUser : IRuleIntegrationUser
    {
        public static User GetUser(int id)
        {
            var manageData = new ManageData();
            var options = new Dictionary<string, object>();
            options.Add("id", id);
            using (var reader = manageData.SqlRequestReader("select * from [User] where Id = @id", options))
            {
                if (reader.Read())
                {
                    return new User((int)reader["Id"],
                        (string)reader["Name"],
                        (string)reader["Email"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        new Role(1, "User"),
                        null
                        );
                }
            }

            throw new Exception($"The database don't want to give data about User with Id = {id}");
        }

        public static User[] GetUsers()
        {
            var manageData = new ManageData();
            List<User> users = new List<User>();
            
            using (var reader = manageData.SqlRequestReader("select * from [User]"))
            {
                if (reader.Read())
                {
                    users.Add(new User((int)reader["Id"],
                        (string)reader["Name"],
                        (string)reader["Email"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        new Role(1, "User"),
                        null));
                }
            }
            return users.ToArray();
        }

        public bool Add(User canvas)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            var manageData = new ManageData();
            var options = new Dictionary<string, object>();
            options.Add("id", id);
            using (var reader = manageData.SqlRequestReader("select * from [User] where Id = @id", options))
            {
                if (reader.Read())
                {
                    return new User((int)reader["Id"],
                        (string)reader["Name"],
                        (string)reader["Email"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        new Role(1, "User"),
                        null
                        );
                }
            }

            throw new Exception($"The database don't want to give data about User with Id = {id}");
        }

        public User[] Get()
        {
            var manageData = new ManageData();
            List<User> users = new List<User>();

            using (var reader = manageData.SqlRequestReader("select * from [User]"))
            {
                if (reader.Read())
                {
                    users.Add(new User((int)reader["Id"],
                        (string)reader["Name"],
                        (string)reader["Email"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        new Role(1, "User"),
                        null));
                }
            }
            return users.ToArray();
        }

        public User[] Get(string login, string password)
        {
            var manageData = new ManageData();
            List<User> users = new List<User>();
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("login", login);
            map.Add("password", password);

            using (var reader = manageData.SqlRequestReader("select * from [User] where Login = @login and Password = @password", map))
            {
                while (reader.Read())
                {
                    users.Add(new User((int)reader["Id"],
                        (string)reader["Name"],
                        (string)reader["Email"],
                        (string)reader["Login"],
                        (string)reader["Password"],
                        new Role(1, "User"),
                        null));
                }
            }
            return users.ToArray();
        }

        public bool Remove(User canvas)
        {
            throw new NotImplementedException();
        }

        public bool Update(User canvas, User newCanvas)
        {
            throw new NotImplementedException();
        }
    }
}
