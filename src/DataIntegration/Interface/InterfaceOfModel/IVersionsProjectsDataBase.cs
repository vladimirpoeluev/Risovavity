using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IVersionsProjectsDataBase
	{
		DbSet<VersionProject> VersionsProjects { get; set; }
	}
}
