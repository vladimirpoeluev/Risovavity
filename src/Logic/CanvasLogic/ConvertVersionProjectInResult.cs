using DomainModel.Model;
using DomainModel.ResultsRequest.Canvas;

namespace Logic.CanvasLogic
{
	public static class ConvertVersionProjectInResult
	{
		public static VersionProjectResult ToResult(this VersionProject versionProject)
		{
			return new VersionProjectResult() 
			{
				Id = versionProject.Id,	
				Name = versionProject.Name,
				Description = versionProject.Description,
				AuthorId = versionProject.AuthorOfVersionId,
				ParentVertionProject = versionProject.ParentOfVersionId ?? -1,
			};

		}
	}
}
