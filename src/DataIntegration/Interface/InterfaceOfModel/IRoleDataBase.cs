using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IRoleDataBase
	{
		DbSet<Role> Roles { get; set; }
	}
}
