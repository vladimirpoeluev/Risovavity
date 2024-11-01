
namespace DomainModel.ResultsRequest
{
	public class EditProfileResult
	{
		public int ProfileId { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
	}
}
