using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic.VersionProjectOperate
{
	public class GetterVersionCanvas : IGetterVersionProject
	{
		IDataBaseModel _db;
		public GetterVersionCanvas(IDataBaseModel context) 
		{
			_db = context;
		}

		public async Task<VersionProjectResult> GetVersionProjectByIdAsync(int id)
		{
			return await GetVersionsProjects().Where(e => e.Id == id).FirstAsync();
		}

		public async Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(string projectName)
		{
			return await GetVersionsProjects().Where(e => e.Name == projectName).ToListAsync();
		}

		public async Task<IEnumerable<VersionProjectResult>> GetVersionProjectsAsync(int skip, int take)
		{
			return await GetVersionsProjects().Skip(skip).Take(take).ToListAsync();
		}

		IQueryable<VersionProjectResult> GetVersionsProjects()
		{
			return _db.VersionsProjects.Select(entity => new VersionProjectResult()
			{
				Id = entity.Id,
				Name = entity.Name,
				Description = entity.Description,
				AuthorId = entity.AuthorOfVersionId,
				ParentVertionProject = entity.ParentOfVersionId ?? -1,
			});
		}
	}
}
