using System.ComponentModel.DataAnnotations;

namespace AvaloniaRisovaviti.ViewModel.FormAdd
{
	public class VersionProjectViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 50, ErrorMessage = "Заполните имя версии")]
		public string Name { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 150, ErrorMessage = "Заполните описание")]
		public string Description { get; set; } = string.Empty;
		public int ParentVertionProject { get; set; }
		public int AuthorId { get; set; }
		
	}
}
