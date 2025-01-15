
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class EditVersionProject : IEditVersionProject
	{
		FabricAutoControllerIntegraion _fabricAuto;
		IAuthenticationUser User { get; set; }
		public EditVersionProject(	FabricAutoControllerIntegraion fabricAuto,
									IAuthenticationUser user) 
		{
			_fabricAuto = fabricAuto;
			User = user;
		}
		public async Task Edit(VerstionProjectEditResutl newVersionProject)
		{
			await _fabricAuto.CreatePostPatser(User, newVersionProject).ExecuteRequestAsync("api/VersionProject/edit");
		}
	}
}
