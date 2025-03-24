using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.ProfileShows;
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
			List<DraftItemViewModel> items = new List<DraftItemViewModel>();
			foreach(Guid guid in guids)
			{
				DraftModel model = await _getterDraft.GetDraftModel(guid);

				items.Add(new DraftItemViewModel()
				{
					Image = ImageAvaloniaConverter.ConvertByteInImage(model.Images),
					Info = model.DraftInfo,
				});

			}
			Items = items;
		}
	}
}
