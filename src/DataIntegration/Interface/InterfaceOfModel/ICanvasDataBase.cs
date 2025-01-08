using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface ICanvasDataBase : IBaseDataModel
	{
		DbSet<Canvas> Canvas { get; set; }
	}
}
