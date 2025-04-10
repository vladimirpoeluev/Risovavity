﻿using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.Model;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic
{
	public class EditerCanvas : IEditerCanvas
	{
		IDataBaseModel _data;
		public EditerCanvas(IDataBaseModel dataBase) 
		{
			_data = dataBase;
		}
		public void UpdateCanvas(CanvasEditerResult canvas)
		{
			Canvas result = _data.Canvas.First(e => e.Id == canvas.Id);

			result.Description = canvas.Description;
			result.Name = canvas.Title;
			result.StatusId = canvas.StatusId;
			result.MainVersionId = canvas.VersionProjectId;
			_data.SaveChanges();
		}

		public async Task UpdateCanvasAsync(CanvasEditerResult canvas)
		{
			CanvasEditerResult result = await _data.Canvas.Select(e => new CanvasEditerResult()
			{
				Id = e.Id,
				Description = e.Description ?? string.Empty,
				VersionProjectId = e.MainVersionId,
				StatusId = e.StatusId,
				Title = e.Name
			}).FirstAsync(e => e.Id == canvas.Id);

			result.Description = canvas.Description;
			result.Title = canvas.Title;
			result.StatusId = canvas.StatusId;
			result.VersionProjectId = canvas.VersionProjectId;
			await _data.SaveChangesAsync();
		}

		public async Task DeleteCanvasAsync(int id)
		{
			var product = await _data.Canvas.FindAsync(id);

			if (product != null)
			{
				_data.Canvas.Remove(product);

				await _data.SaveChangesAsync();
			}
		}
	}
}
