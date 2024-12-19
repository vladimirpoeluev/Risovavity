
namespace DataIntegration.Interface
{
	public interface IGetterKeys
	{
		Task<IEnumerable<string>> GetKeys(string pattern);
	}
}
