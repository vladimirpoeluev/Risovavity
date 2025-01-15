
using DomainModel.Integration;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class SearchCanvas : ISearcherCanvas
	{
		FabricAutoControllerIntegraion _fabricAuto;
		IAuthenticationUser User { get; set; }
		public SearchCanvas(FabricAutoControllerIntegraion fabricAuto, IAuthenticationUser user) 
		{
			_fabricAuto = fabricAuto;
			User = user;
		}
		public async Task<IEnumerable<CanvasResult>> Search(string keyworld)
		{
			return await _fabricAuto.CreateGetPatser(User).GetResultAsync<IEnumerable<CanvasResult>>($"api/canvas/search/{keyworld}");
		}
	}
}
