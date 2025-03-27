using AvaloniaRisovaviti.Services.Interface;
using System;

namespace AvaloniaRisovaviti.Services
{
	internal class IteraterItems : IIteraterItems
	{
		Action<(int skip, int take)> _action;
		int _next;
		int _count;
		public IteraterItems(int count, Action<(int skip, int take)> action)
		{
			_next = count;
			_action = action;
		} 
		public void Back()
		{
			_action((_count * _next, _next));
			if(_count > 0)
				_count--;
		}

		public void Next()
		{
			_action((_count * _next, _next));
			_count++;
		}
	}
}
