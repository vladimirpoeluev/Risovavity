
using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic
{
	public class SearcherCanvas : ISearcherCanvas
	{
		ICanvasDataBase _data;
		public SearcherCanvas(ICanvasDataBase data) 
		{
			_data = data;
		}

		public async Task<IEnumerable<CanvasResult>> Search(string keyworld)
		{
			return await _data.Canvas.Select(e => new CanvasResult()
			{
				Name = e.Name,
				Description = e.Description ?? string.Empty,
				Id = e.Id,
				UserId = e.AuthorId,
				VersionId = e.MainVersionId
			}).Where(e => e.Name.Contains(keyworld)).ToListAsync();
		}
	}
}
