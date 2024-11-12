
namespace DomainModel.ResultsRequest.Canvas
{
	public class VersionProjectForAddResult
	{
		public string Name { get; set; }
		public string Descriptoin { get; set; }
		public int ParentVertionProjectId { get; set; }
		public byte[] Image { get; set; }
	}
}
