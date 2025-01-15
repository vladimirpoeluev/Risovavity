
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class ServiceLikesOfVersionProject : ILikesOfVersitonService
	{
		IAuthenticationUser User { get; set; }
		FabricAutoControllerIntegraion _fabricAuto;
		public ServiceLikesOfVersionProject(FabricAutoControllerIntegraion fabricAuto,
											IAuthenticationUser user)
		{
			_fabricAuto = fabricAuto;
			User = user;
		}
		public async Task<int> CouintLikes(int versionProjectId)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<int>($"api/versionproject/couint-likes/{versionProjectId}");
		}

		public async Task<bool> IsLike(int versionId)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<bool>($"api/versionproject/islike/{versionId}");
		}

		public async Task Like(int versionId)
		{
			await _fabricAuto.CreatePostPatser<object>(User, null).ExecuteRequestAsync($"api/versionproject/like/{versionId}");
		}

		public async Task UnLike(int versionId)
		{
			await _fabricAuto.CreatePostPatser<object>(User, null).ExecuteRequestAsync($"api/versionproject/unlike/{versionId}");
		}
	}
}
