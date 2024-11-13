using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class GetterVersionProfile : IGetterVersionProject
	{
		FabricAutoControllerIntegraion _operates;
		IAuthenticationUser _user;

		public GetterVersionProfile(IAuthenticationUser user)
		{
			_operates = new CreaterAuthoControllersIntegraion();
			_user = user;
		}

		public Task<VersionProjectResult> GetVersionProjectByIdAsync(int id)
		{
			var getter = _operates.CreateGetPatser<VersionProjectResult>(_user);
			return Task.FromResult(getter.GetResult<VersionProjectResult>($"api/VersionProject/get/{id}"));
		}

		public Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(string projectName)
		{
			var getter = _operates.CreateGetPatser<VersionProjectResult>(_user);
			return Task.FromResult(getter.GetResult<IEnumerable<VersionProjectResult>>($"api/VersionProject/getByName/{projectName}"));
		}

		public Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(int skip, int take)
		{
			var getter = _operates.CreateGetPatser<VersionProjectResult>(_user);
			return Task.FromResult(getter.GetResult<IEnumerable<VersionProjectResult>>($"api/VersionProject/get?skip={take}&take={take}"));
		}
	}
}
