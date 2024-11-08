using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
    public interface IAdderCanvas
    {
        Task AddCanvas(CanvasAddResult canvasAddResult);
    }
}
