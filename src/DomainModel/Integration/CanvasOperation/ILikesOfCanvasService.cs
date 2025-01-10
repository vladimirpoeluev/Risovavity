

namespace DomainModel.Integration.CanvasOperation
{
	public interface ILikesOfCanvasService
	{
		Task Like(int canvasId);
		Task UnLike(int canvasId);
		Task<int> CouintLikes(int canvasId);
		Task<bool> IsLike(int canvasId);
	}
}
