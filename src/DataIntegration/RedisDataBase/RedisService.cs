using DataIntegration.Interface;
using System.Text.Json;

namespace DataIntegration.RedisDataBase
{
	public class RedisService : IRedisService
	{
		RedisConection _connection;
		public RedisService(string connectionString)
		{
			_connection = new RedisConection(connectionString);
		}

		public async Task AddObject<T>(string key, T obj)
		{
			string result = JsonSerializer.Serialize(obj);
			await _connection.GetDataBase().StringSetAsync(key, result);
		}

		public async Task AddObject<T>(string key, T obj, TimeSpan expire)
		{
			await AddObject(key, obj);
			await _connection.GetDataBase().KeyExpireAsync(key, expire);
		}

		public async Task<T> GetObject<T>(string key)
		{
			string result = await _connection.GetDataBase().StringGetAsync(key);
			if (string.IsNullOrEmpty(result))
			{
				return default;
			}
			return JsonSerializer.Deserialize<T>(result);

		}

		public async Task DeleteObject(string key)
		{
			await _connection.GetDataBase().KeyDeleteAsync(key);
		}
	}
}
