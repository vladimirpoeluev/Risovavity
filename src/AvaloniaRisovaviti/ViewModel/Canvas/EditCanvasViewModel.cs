
using AvaloniaEdit.Utils;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class EditCanvasViewModel : BaseViewModel
	{
		[Reactive]
		public string Name { get; set; } = string.Empty;

		[Reactive]
		public string Description { get; set; } = string.Empty;

		public ReactiveCommand<Unit, Task<CanvasResult>> EditCanvas { get; set; }

		IEditerCanvas _editer;

		public CanvasResult CanvasResult { get; set; }

		public EditCanvasViewModel(IEditerCanvas editer)
		{
			_editer = editer;
			EditCanvas = ReactiveCommand.Create(EditClick);
		}

		async Task<CanvasResult> EditClick()
		{
			await _editer.UpdateCanvasAsync(new CanvasEditerResult()
			{
				Id = CanvasResult.Id,
				Description = Description,
				Title = Name,
				StatusId = 1,
				VersionProjectId = CanvasResult.VersionId,
			});
			return CanvasResult;
		}


	}
}
