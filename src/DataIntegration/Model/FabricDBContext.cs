using DataIntegration.Interface;
using Microsoft.Extensions.Configuration;

namespace DataIntegration.Model
{
	public class FabricDBContext : IFabricDBContext
	{
		IConfiguration _configuration;
		public FabricDBContext(IConfiguration configuration) 
		{
			_configuration = configuration;
		}
		public DatabaseContext CreateContext() => new DatabaseContext(_configuration); 
	}
}
