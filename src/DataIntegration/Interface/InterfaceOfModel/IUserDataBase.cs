using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IUserDataBase : IBaseDataModel
	{
		DbSet<User> Users { get; set; }
	}
}
