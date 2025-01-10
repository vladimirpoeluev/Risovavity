
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Model
{
	[Table("LikeOfCanvas")]
	public class LikeOfCanvas
	{
		public int CanvasId { get; set; }
		public Canvas Canvas { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }
	}
}
