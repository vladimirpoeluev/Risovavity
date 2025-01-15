
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class ServiceLikesOfCanvas : ILikesOfCanvasService
	{
		IAuthenticationUser User { get; set; }
		FabricAutoControllerIntegraion _fabricAuto;
		public ServiceLikesOfCanvas(FabricAutoControllerIntegraion fabricAuto,
									IAuthenticationUser user) 
		{
			_fabricAuto = fabricAuto;
			User = user;
		}
		public async Task<int> CouintLikes(int canvasId)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<int>($"api/canvas/couint-likes/{canvasId}");
		}

		public async Task<bool> IsLike(int canvasId)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<bool>($"api/canvas/islike/{canvasId}");
		}

		public async Task Like(int canvasId)
		{
			await _fabricAuto.CreatePostPatser<object>(User, null).ExecuteRequestAsync($"api/canvas/like/{canvasId}");
		}

		public async Task UnLike(int canvasId)
		{
			await _fabricAuto.CreatePostPatser<object>(User, null).ExecuteRequestAsync($"api/canvas/unlike/{canvasId}");
		}
	}
}
