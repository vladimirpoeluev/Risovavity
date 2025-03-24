using DataIntegration.Interface.InterfaceOfModel;
using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Logic.CanvasLogic
{
	public class EditMainVersionInCanvas : IEditMainVerstionInCanvas
	{
		private IDataBaseModel _data;
		private IConfiguration _configuration;
		private static object _locker = new object();
		public EditMainVersionInCanvas(IDataBaseModel dataBaseModel, IConfiguration configuration) 
		{
			_data = dataBaseModel;
			_configuration = configuration;
		}
		public async Task SelectMainVerstion(MainVersionInCanvasResutl mainVersion)
		{
			try
			{
				var canvas = await _data.Canvas.FirstAsync(e => e.Id == mainVersion.CanvasId);
				if (_data.VersionsProjects.FirstOrDefaultAsync(e => e.Id == mainVersion.VersitonId) == null)
					return;
				
				canvas.MainVersionId = mainVersion.VersitonId;

				_data.SaveChanges();
			}
			catch (Exception ex) 
			{
				await TwoTry(mainVersion);
			}
		}
		private async Task TwoTry(MainVersionInCanvasResutl mainVersion)
		{
			var data = new DatabaseContext(_configuration);
			var canvas = await data.Canvas.FirstAsync(e => e.Id == mainVersion.CanvasId);
			if (data.VersionsProjects.FirstOrDefaultAsync(e => e.Id == mainVersion.VersitonId) == null)
				return;

			canvas.MainVersionId = mainVersion.VersitonId;

			data.SaveChanges();
		}
	}
}
