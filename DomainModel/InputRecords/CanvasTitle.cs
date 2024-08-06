using DomainModel.Model;

namespace DomainModel.InputRecords
{
    public class CanvasTitle
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
		public User IdAuthorNavigation { get; set; } = null!;
		public Status IdStatusNavigation { get; set; } = null!;
	}
}
