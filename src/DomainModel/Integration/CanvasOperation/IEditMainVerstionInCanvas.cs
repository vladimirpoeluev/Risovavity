
using DomainModel.ResultsRequest.Canvas;

namespace DomainModel.Integration.CanvasOperation
{
	public interface IEditMainVerstionInCanvas
	{
		Task SelectMainVerstion(MainVersionInCanvasResutl mainVersion);
	}
}
