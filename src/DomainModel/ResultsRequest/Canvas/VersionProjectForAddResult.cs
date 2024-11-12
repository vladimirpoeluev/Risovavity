
namespace DomainModel.ResultsRequest.Canvas
{
	public class VersionProjectForAddResult
	{
		string Name { get; set; }
		string Descriptoin { get; set; }
		int ParentVertionProjectId { get; set; }
		byte[] Image { get; set; }
	}
}
