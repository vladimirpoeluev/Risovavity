using DataIntegration.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Logic.CanvasLogic
{
	public class GetterVersionsByParent : IGetterVersionByParentVersion
	{
		private DatabaseContext DatabaseContext { get; set; }
		public int Skip { get; set; }
		public int Take { get; set; }

		public GetterVersionsByParent(DatabaseContext databaseContext)
		{
			DatabaseContext = databaseContext;
			Skip = 0;
			Take = 50;
		}
		public async Task<IEnumerable<VersionProjectResult>> GetVersionsByParent(VersionProjectResult parent)
		{
			return await DatabaseContext.VersionsProjects
					.Where(x => x.ParentOfVersion.Id == parent.Id)
					.Select(x => x.ToResult())
					.Skip(Skip).Take(Take)
					.ToListAsync();
		}
	}
}
