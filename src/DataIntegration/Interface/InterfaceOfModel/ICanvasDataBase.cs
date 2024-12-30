using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface ICanvasDataBase
	{
		DbSet<Canvas> Canvas { get; set; }
	}
}
