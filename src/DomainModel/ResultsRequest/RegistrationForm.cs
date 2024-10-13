
using DomainModel.Model;

namespace DomainModel.ResultsRequest
{
	public class RegistrationForm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public User GetUser()
		{
			return new User()
			{
				Id = Id,
				Name = Name,
				Email = Email,
				Login = Login,
				Password = Password,
				IdRole = 2,
				Role = new Role() { Name = "Author" }
			};
		}
	}
}
