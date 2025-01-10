
namespace DomainModel.Integration.CanvasOperation
{
	public interface ILikesOfVersitonService
	{
		Task Like(int verstionId);
		Task UnLike(int verstionId);
		Task<int> CouintLikes(int verstionId);
		Task<bool> IsLike(int verstionId);
	}
}
