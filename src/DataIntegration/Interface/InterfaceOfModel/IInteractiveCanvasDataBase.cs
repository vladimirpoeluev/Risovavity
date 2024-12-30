using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IInteractiveCanvasDataBase
	{
		DbSet<InteractiveCanvas> InteractiveCanvas { get; set; }
	}
}
