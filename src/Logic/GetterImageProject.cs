using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;

namespace Logic
{
	public class GetterImageProject : IGetterImageProject
	{
		private DatabaseContext _db;

		public GetterImageProject(DatabaseContext db)
		{
			_db = db;
		}
		public async Task<ImageResult> GetImageResult(int idProject)
		{
			return await _db.VersionsProjects.Where(entity => entity.Id == idProject)
				.Select(entity => new ImageResult()
				{
					Image = entity.Image,
					Name = entity.Name,
				}).FirstOrDefaultAsync() ?? new ImageResult()
				{
					Name = "Breaked image",
					Image = [],
				};
		}
	}
}
