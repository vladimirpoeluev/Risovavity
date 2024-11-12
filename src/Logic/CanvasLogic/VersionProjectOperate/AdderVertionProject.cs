using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic.CanvasLogic.VersionProjectOperate
{
	public class AdderVertionProject : IAdderVersionProject
	{
		DatabaseContext _db;
		UserResult _userResult;
		public AdderVertionProject(DatabaseContext db, UserResult user) 
		{
			_db = db;
			_userResult = user;
		}
		public async Task AddVertionProjectAsync(VersionProjectForAddResult result)
		{
			await _db.VersionsProjects.AddAsync(new DomainModel.Model.VersionProject()
			{
				Name = result.Name,
				Description = result.Descriptoin,
				Image = result.Image,
				AuthorOfVersionId = _userResult.Id,
				ParentOfVersionId = result.ParentVertionProjectId,
			});
			await _db.SaveChangesAsync();
		}

		public async Task DeleteVertionProjectAsync(int id)
		{
			var version = await _db.VersionsProjects.Where(e => e.Id == id).FirstAsync();
			_db.VersionsProjects.Remove(version);
			await _db.SaveChangesAsync();
		}
	}
}
