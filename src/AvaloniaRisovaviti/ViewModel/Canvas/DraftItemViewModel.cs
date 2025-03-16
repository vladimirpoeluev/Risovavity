using Avalonia.Media;
using AvaloniaRisovaviti.Model;
using System;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class DraftItemViewModel
	{
		public DraftInfo Info { get; set; }
		public IImage Image { get; set; }
		private Guid Guid { get; set; }
	}
}
