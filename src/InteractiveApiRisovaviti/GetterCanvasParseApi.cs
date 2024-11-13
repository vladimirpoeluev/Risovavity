using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	class GetterCanvasParseApi : IGetterCanvas
	{
		FabricAutoControllerIntegraion FabricAutoControllerIntegraion { get; set; }
		IAuthenticationUser User { get; set; }

		public GetterCanvasParseApi(IAuthenticationUser user)
		{
			FabricAutoControllerIntegraion = new CreaterAuthoControllersIntegraion();
			User = user;
		}

		public Task<CanvasResult> GetAsync(int id)
		{ 
			var getter = FabricAutoControllerIntegraion.CreateGetPatser<CanvasResult>(User);
			return Task.FromResult(getter.GetResult<CanvasResult>($"api/canvas/get/{id}"));
		}

		public Task<IEnumerable<CanvasResult>> GetAsync(int skip, int take)
		{
			var getter = FabricAutoControllerIntegraion.CreateGetPatser<CanvasResult>(User);
			return Task.FromResult(getter.GetResult<IEnumerable<CanvasResult>>($"api/VersionProject/get?skip={skip}&take={take}"));
		}

		public Task<IEnumerable<CanvasResult>> GetAsync(string name)
		{
			var getter = FabricAutoControllerIntegraion.CreateGetPatser<CanvasResult>(User);
			return Task.FromResult(getter.GetResult<IEnumerable<CanvasResult>>($"api/VersionProject/getByName/{name}"));
		}
	}
}
