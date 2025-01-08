using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IInteractiveCanvasDataBase : IBaseDataModel
	{
		DbSet<InteractiveCanvas> InteractiveCanvas { get; set; }
	}
}
