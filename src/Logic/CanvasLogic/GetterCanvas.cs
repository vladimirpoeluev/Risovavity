using DataIntegration.Interface.InterfaceOfModel;
using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic
{
	public class GetterCanvas : IGetterCanvas
	{
		ICanvasDataBase _db { get; set; }
		UserResult _userResult;

		public GetterCanvas(DatabaseContext db, UserResult user) 
		{
			_db = db;
			_userResult = user;
		}

		public GetterCanvas(ICanvasDataBase db)
		{
			_db = db;
			_userResult = new UserResult();

		}
		public async Task<CanvasResult> GetAsync(int id)
		{
			return await _db.Canvas.Include(entity => entity.Author)
				.Select(canvas => new CanvasResult() 
				{ 
					Id = canvas.Id,
					Name = canvas.Name,
					Description = canvas.Description ?? String.Empty,
					UserId = canvas.Author.Id,
					VersionId = canvas.MainVersionId,
				}).Where(entity => entity.Id == id).FirstOrDefaultAsync() ?? new CanvasResult();
		}

		public async Task<IEnumerable<CanvasResult>> GetAsync(int skip, int take)
		{
			return await _db.Canvas.Include(entity => entity.Author)
				.Select(canvas => new CanvasResult()
				{
					Id = canvas.Id,
					Name = canvas.Name,
					Description = canvas.Description ?? String.Empty,
					UserId = canvas.Author.Id,
					VersionId = canvas.MainVersionId,
				}).Skip(skip).Take(take).ToListAsync();
		}

		public async Task<IEnumerable<CanvasResult>> GetAsync(string name)
		{
			return await _db.Canvas.Include(entity => entity.Author)
				.Select(canvas => new CanvasResult()
				{
					Id = canvas.Id,
					Name = canvas.Name,
					Description = canvas.Description ?? String.Empty,
					UserId = canvas.Author.Id,
					VersionId = canvas.MainVersionId,
				}).Where(entity => entity.Name == name).ToListAsync();
		}
	}
}
