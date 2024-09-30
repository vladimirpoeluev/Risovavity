
using DomainModel.Model;
using System.ComponentModel;

namespace DomainModel.ResultsRequest
{
	public class UserFullResult
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Email { get; set; } = null!;

		public string Password { get; set; } = null!;

		public string Login { get; set; } = null!;

		public virtual RoleResult IdRoleNavigation { get; set; } = null!;

		public static UserFullResult CreateResultFromUser(User user)
		{
			return new UserFullResult()
			{
				Id = user?.Id ?? 0,
				Name = user?.Name ?? "Отсутствует",
				Email = user?.Email ?? "Отсутствует",
				IdRoleNavigation = RoleResult.CreateRoleResultFromRole(user?.Role ?? new Role()),
				Password = user?.Password ?? "Отсутствует",
				Login = user?.Login ?? "Отсутствует"
			};

		}
	}
}
