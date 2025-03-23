using AvaloniaRisovaviti.Services.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class DraftesViewModel : BaseViewModel
	{
		[Reactive]
		public IEnumerable<DraftItemViewModel> Items { get; set; }
		IGetterDraftProject _getterDraft;

		public DraftesViewModel(IGetterDraftProject getterDraft) : base()
		{
			Items = new List<DraftItemViewModel>();
			_getterDraft = getterDraft;
		}
		
		public override async void Load()
		{
			IEnumerable<Guid> guids = await _getterDraft.GetGuids();
			Items = guids.Select(guid =>
			{
				return new DraftItemViewModel()
				{
					Info = new Model.DraftInfo()
					{
						Name = "Test data"
					}
				};
			});
		}
	}
}
