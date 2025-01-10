

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IDataBaseModel : 
		ICanvasDataBase,
		IVersionsProjectsDataBase,
		IInteractiveCanvasDataBase,
		IRoleDataBase,
		IStatusesDataBase,
		IUserDataBase,
		ILikesOfCanvasDataBase,
		ILikeOfVersionProjectDataBase; 
}
