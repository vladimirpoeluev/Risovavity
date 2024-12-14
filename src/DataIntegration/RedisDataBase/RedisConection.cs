using StackExchange.Redis;

namespace DataIntegration.RedisDataBase
{
	public class RedisConection
	{
		private readonly ConnectionMultiplexer _connetion;

		public RedisConection(string connetionString)
		{
			_connetion = ConnectionMultiplexer.Connect(connetionString);
		}

		public IDatabase GetDataBase()
		{
			return _connetion.GetDatabase();
		}
	}
}
