
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IGetterImageProject
	{
		Task<ImageResult> GetImageResult(int idProject);
	}
}
