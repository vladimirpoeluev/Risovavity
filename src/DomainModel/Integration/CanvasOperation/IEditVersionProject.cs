
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IEditVersionProject
	{
		Task Edit(VerstionProjectEditResutl newVersionProject);
	}
}
