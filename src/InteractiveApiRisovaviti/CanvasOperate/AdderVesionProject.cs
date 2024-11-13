
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

		public Task AddVertionProjectAsync(VersionProjectForAddResult result)
		{
			var poster = _operates.CreatePostPatser(_user, result);
			poster.ExecuteReques("api/VersionProject/add");
			return Task.CompletedTask;
		}

		public Task DeleteVertionProjectAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
