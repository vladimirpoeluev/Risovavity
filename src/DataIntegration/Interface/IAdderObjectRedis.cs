
namespace DataIntegration.Interface
{
	public interface IAdderObjectRedis
	{
		Task AddObject<T>(string key, T obj);
		Task AddObject<T>(string key, T obj, TimeSpan expire);
	}
}
