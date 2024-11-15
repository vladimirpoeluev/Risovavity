
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class AdderVesionProject : IAdderVersionProject
	{
		FabricAutoControllerIntegraion _operates;
		IAuthenticationUser _user;
		public AdderVesionProject(IAuthenticationUser user)
		{
			_user = user;
			_operates = new CreaterAuthoControllersIntegraion();
		}

		public async Task AddVertionProjectAsync(VersionProjectForAddResult result)
		{
			var poster = _operates.CreatePostPatser(_user, result);
			await poster.ExecuteRequestAsync("api/VersionProject/add");
		}

		public Task DeleteVertionProjectAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
