﻿using System.ComponentModel.DataAnnotations;

namespace AvaloniaRisovaviti.ViewModel.FormAdd
{
	public class VersionProjectViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50, ErrorMessage = "Заполните имя версии")]
		public string Name { get; set; }
		[Required]
		[StringLength(150, ErrorMessage = "Заполните описание")]
		public string Description { get; set; }
		public int ParentVertionProject { get; set; }
		public int AuthorId { get; set; }
		
	}
}
