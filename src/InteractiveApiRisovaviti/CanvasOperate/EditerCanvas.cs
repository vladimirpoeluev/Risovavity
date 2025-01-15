
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti.CanvasOperate
{
	public class EditerCanvas : IEditerCanvas
	{
		IAuthenticationUser User { get; set; }
		FabricAutoControllerIntegraion _fabricAuto;
		public EditerCanvas(IAuthenticationUser user,
										FabricAutoControllerIntegraion fabricAuto)
		{
			User = user;
			_fabricAuto = fabricAuto;
		}

		public async Task DeleteCanvasAsync(int id)
		{
			await _fabricAuto.CreatePostPatser<object>(User, null).ExecuteRequestAsync($"api/canvas/delete/{id}");
		}

		public void UpdateCanvas(CanvasEditerResult canvas)
		{
			UpdateCanvasAsync(canvas).Wait();
		}

		public async Task UpdateCanvasAsync(CanvasEditerResult canvas)
		{
			await _fabricAuto.CreatePostPatser(User, canvas).ExecuteRequestAsync($"api/canvas/edit/{canvas.Id}");
		}
	}
}
