
using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IGetterCanvas
	{
		Task<CanvasResult> GetAsync(int id);
		Task<IEnumerable<CanvasResult>> GetAsync(int skip, int take);
		Task<IEnumerable<CanvasResult>> GetAsync(string name);
	}
}
