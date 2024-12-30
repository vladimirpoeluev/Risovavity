using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IStatusesDataBase
	{
		DbSet<Status> Statuses { get; set; }
	}
}
