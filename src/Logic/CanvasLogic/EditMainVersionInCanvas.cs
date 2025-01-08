using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.Model;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic
{
	public class EditMainVersionInCanvas : IEditMainVerstionInCanvas
	{
		private IDataBaseModel _data;
		public EditMainVersionInCanvas(IDataBaseModel dataBaseModel) 
		{
			_data = dataBaseModel;
		}
		public async Task SelectMainVerstion(MainVersionInCanvasResutl mainVersion)
		{
			try
			{
				var canvas = await _data.Canvas.FirstAsync(e => e.Id == mainVersion.CanvasId);
				if (_data.VersionsProjects.FirstOrDefaultAsync(e => e.Id == mainVersion.VersitonId) == null)
					return;
				canvas.MainVersionId = mainVersion.VersitonId;
				await _data.SaveChangesAsync();
			}
			catch (Exception) 
			{

			}
		}
	}
}
