using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IVersionsProjectsDataBase : IBaseDataModel
	{
		DbSet<VersionProject> VersionsProjects { get; set; }
	}
}
