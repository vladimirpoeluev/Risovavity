using DataIntegration.Model;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;
using DomainModel.Integration;

namespace Logic
{
    public class GetterWorkByAuthorId : IGetterWorkByAuthorId
	{
        public DatabaseContext _context;
        public GetterWorkByAuthorId(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public async Task<IEnumerable<CanvasResult>> GetCanvasByAuthorId(int id, int skip, int take) 
            => await _context.Canvas.Where(canvas => canvas.AuthorId == id).Select(canvas => new CanvasResult()
            {
                Id = canvas.Id,
                Description = canvas.Description ?? string.Empty,
                Name = canvas.Name,
                UserId = canvas.AuthorId,
                VersionId = canvas.MainVersionId,
            }).Skip(skip).Take(take).ToListAsync();

        public async Task<IEnumerable<VersionProjectResult>> GetVersionProjectResultsByAuthorId(int id, int skip, int take)
            => await _context.VersionsProjects.Where(version => version.AuthorOfVersionId == id).Select(version => new VersionProjectResult()
            {
                Id = version.Id,
                Description= version.Description ?? string.Empty,
                Name = version.Name,
                AuthorId = version.AuthorOfVersionId,
                ParentVertionProject = version.ParentOfVersionId ?? -1,
            }).Skip(skip).Take(take).ToListAsync();
    }
}
