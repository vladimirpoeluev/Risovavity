namespace DomainModel.ResultsRequest
{

	public class PermissionResult
	{
		public bool? Read { get; set; }
		public bool? Edit { get; set; }
		public bool? AddVerstion { get; set; }
		public bool? Delete { get; set; }
	}
}
