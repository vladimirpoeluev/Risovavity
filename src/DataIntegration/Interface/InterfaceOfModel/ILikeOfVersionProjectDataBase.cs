
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface ILikeOfVersionProjectDataBase : IBaseDataModel
	{
		DbSet<LikeOfVersionProject> LikeOfVersionProjects { get; set; }
	}
}
