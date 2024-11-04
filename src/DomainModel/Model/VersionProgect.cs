
namespace DomainModel.Model
{
	public class VersionProgect
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public byte[] Image { get; set; }
		public VersionProgect ParentVersion { get; set; }
	}
}
