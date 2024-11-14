using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic
{
	public class GetterCanvas : IGetterCanvas
	{
		DatabaseContext _db { get; set; }
		UserResult _userResult;

		public GetterCanvas(DatabaseContext db, UserResult user) 
		{
			_db = db;
			_userResult = user;
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
				}).Where(entity => entity.Id == id).FirstAsync();
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
