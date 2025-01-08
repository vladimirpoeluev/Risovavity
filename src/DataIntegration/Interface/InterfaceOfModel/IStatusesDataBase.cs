using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IStatusesDataBase : IBaseDataModel
	{
		DbSet<Status> Statuses { get; set; }
	}
}
