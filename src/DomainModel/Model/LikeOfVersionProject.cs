
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Model
{
	[Table("LikeOfVersionProject")]
	public class LikeOfVersionProject
	{
		public int VersionProjectId { get; set; }
		public VersionProject VersionProject { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
