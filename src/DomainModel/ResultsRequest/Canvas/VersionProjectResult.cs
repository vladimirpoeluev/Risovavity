

namespace DomainModel.ResultsRequest.Canvas
{
	public class VersionProjectResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentVertionProject {  get; set; }
		public int AuthorId { get; set; }
	}
}
