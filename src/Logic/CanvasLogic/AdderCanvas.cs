using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;

namespace Logic.CanvasLogic
{
	public class AdderCanvas : IAdderCanvas
	{
		private DatabaseContext _context;
		private UserResult _userResult;

		public AdderCanvas(UserResult user, DatabaseContext context)
		{
			_context = context;
			_userResult = user;
		}

		public async Task AddCanvas(CanvasAddResult canvasAddResult)
		{
			var versionProject = new VersionProject() 
			{
				Name = canvasAddResult.VersionProject.Name,
				Description = canvasAddResult.VersionProject.Description,
				AuthorOfVersionId = _userResult.Id,
				Image = canvasAddResult.VersionProject.Image,
			};

			var canvas = new Canvas()
			{
				Name = canvasAddResult.Title,
				Description = canvasAddResult.Description,
				AuthorId = _userResult.Id,
				MainVersion = versionProject,
				StatusId = 1,
			};

			await _context.VersionsProjects.AddAsync(versionProject);
			await _context.Canvas.AddAsync(canvas);
		}
	}
}
