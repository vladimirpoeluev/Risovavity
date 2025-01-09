using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
    public interface IEditerCanvas
    {
        void UpdateCanvas(CanvasEditerResult canvas);
        Task UpdateCanvasAsync(CanvasEditerResult canvas);
    }
}
