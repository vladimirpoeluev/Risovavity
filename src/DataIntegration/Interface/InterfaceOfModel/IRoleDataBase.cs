using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IRoleDataBase : IBaseDataModel
	{
		DbSet<Role> Roles { get; set; }
	}
}
