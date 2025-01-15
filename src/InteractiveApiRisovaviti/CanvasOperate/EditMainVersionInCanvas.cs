
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class EditMainVersionInCanvas : IEditMainVerstionInCanvas
	{
		IAuthenticationUser User { get; set; }
		FabricAutoControllerIntegraion _fabricAuto;
		public EditMainVersionInCanvas(	IAuthenticationUser user, 
										FabricAutoControllerIntegraion fabricAuto) 
		{
			User = user;
			_fabricAuto = fabricAuto;
		}
		public async Task SelectMainVerstion(MainVersionInCanvasResutl mainVersion)
		{
			await _fabricAuto.CreatePostPatser(User, mainVersion).ExecuteRequestAsync("api/canvas/edit/mainVersion");
		}
	}
}
