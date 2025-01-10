using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface ILikesOfCanvasDataBase : IBaseDataModel
	{
		DbSet<LikeOfCanvas> LikeOfCanvas { get; set; }
	}
}
