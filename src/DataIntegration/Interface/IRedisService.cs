
namespace DataIntegration.Interface
{
	public interface IRedisService : IDeleterObjectRedis, IAdderObjectRedis, IGetterObjectRedis
	{
	}
}