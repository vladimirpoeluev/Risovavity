using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.Canvas
{
    public interface IAdderCanvas
    {
        Task AddCanvas(CanvasAddResult canvasAddResult);
    }
}
