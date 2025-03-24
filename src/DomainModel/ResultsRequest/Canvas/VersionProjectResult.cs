

using DomainModel.Model;

namespace DomainModel.ResultsRequest.Canvas
{
	public class VersionProjectResult
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int ParentVertionProject {  get; set; }
		public int AuthorId { get; set; }
		public VersionProjectResult() { }
		public VersionProjectResult(VersionProject versionProject)
		{
			Id = versionProject.Id;
			Name = versionProject.Name;
			Description = versionProject.Description;
			ParentVertionProject = versionProject.ParentOfVersionId ?? -1;
			AuthorId = versionProject.AuthorOfVersionId;
		}
	}
}
