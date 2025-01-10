

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataIntegration.Interface.InterfaceOfModel
{
	public interface IBaseDataModel
	{
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
		where TEntity : class;
	}
}
