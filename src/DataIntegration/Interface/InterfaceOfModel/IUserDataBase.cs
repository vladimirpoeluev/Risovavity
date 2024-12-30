using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IUserDataBase
	{
		DbSet<User> Users { get; set; }
	}
}
