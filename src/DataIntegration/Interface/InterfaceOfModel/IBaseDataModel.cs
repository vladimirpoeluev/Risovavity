

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IBaseDataModel
	{
		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}
