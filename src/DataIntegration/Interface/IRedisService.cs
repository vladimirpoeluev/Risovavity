
namespace DataIntegration.Interface
{
	public interface IRedisService
	{
		Task AddObject<T>(string key, T obj);
		Task AddObject<T>(string key, T obj, TimeSpan expire);
		Task<T> GetObject<T>(string key);
	}
}