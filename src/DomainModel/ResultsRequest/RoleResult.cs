using DomainModel.Model;

namespace DomainModel.ResultsRequest
{
	public class RoleResult
	{
		public int Id { get; set; }
		private static readonly RoleResult NotRole = new RoleResult() { Id = -1, Name = nameof(NotRole) };
		public string Name { get; set; } = null!;

		public Role GetRoleObjection()
		{
			return new Role { Id = Id, Name = Name };
		}

		public static RoleResult CreateRoleResultFromRole(Role role)
		{
			try
			{
				return new RoleResult()
				{
					Id = role.Id,
					Name = role.Name
				};
			}catch
			{
				return NotRole;
			}
			
		}
	}
}
