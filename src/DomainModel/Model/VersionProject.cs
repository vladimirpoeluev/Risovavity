
using System.Collections.ObjectModel;

namespace DomainModel.Model
{
	public class VersionProject
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public byte[] Image { get; set; }
		public int? ParentOfVersionId { get; set; } = null!;
		public int AuthorOfVersionId { get; set; }

		public VersionProject ParentOfVersion { get; set; } = null!;
		public IEnumerable<VersionProject> DescendantsVersionProject { get; set; }
		public User AuthorOfVersion { get; set; }
		public Canvas Canvas { get; set; }
		public Collection<LikeOfVersionProject> LikeOfVersions { get; set; }

	}
}
