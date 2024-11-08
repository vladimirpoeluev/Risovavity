using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
    public interface IGetterCanvas
    {
        Task<CanvasResult> GetAsync(int id);
        Task<IEnumerable<CanvasResult>> GetAsync(int skip, int take);
        Task<IEnumerable<CanvasResult>> GetAsync(string name);
    }
}
