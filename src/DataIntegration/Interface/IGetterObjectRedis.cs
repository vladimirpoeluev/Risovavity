
namespace DataIntegration.Interface
{
	public interface IGetterObjectRedis
	{
		Task<T> GetObject<T>(string key);
	}
}
