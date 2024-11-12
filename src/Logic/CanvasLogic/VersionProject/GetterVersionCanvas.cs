using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic.VersionProject
{
	public class GetterVersionCanvas : IGetterVersionProject
	{
		DatabaseContext _db;
		public GetterVersionCanvas(DatabaseContext context) 
		{
			_db = context;
		}

		public async Task<VersionProjectResult> GetVersionProjectByIdAsync(int id)
		{
			return await _db.VersionsProjects.Select(entity => new VersionProjectResult()
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				AuthorId = entity.AuthorOfVersionId,
				ParentVertionProject = entity.ParentOfVersionId.Value,
			}).Where(e => e.Id == id).FirstAsync();

		}

		public async Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(string projectName)
		{
			return await _db.VersionsProjects.Select(entity => new VersionProjectResult()
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				AuthorId = entity.AuthorOfVersionId,
				ParentVertionProject = entity.ParentOfVersionId.Value,
			}).Where(e => e.Name == projectName).ToListAsync();
		}

		public async Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(int skip, int take)
		{
			return await _db.VersionsProjects.Select(entity => new VersionProjectResult()
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				AuthorId = entity.AuthorOfVersionId,
				ParentVertionProject = entity.ParentOfVersionId.Value,
			}).Skip(skip).Take(take).ToListAsync();
		}
	}
}
