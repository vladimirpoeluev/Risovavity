
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Login { get; set; } = null!;

	[Column(TypeName = "varchar(200)")]
	public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public byte[]? Icon { get; set; }

    public virtual ICollection<Canvas> Canvas { get; set; }

    public virtual Role Role { get; set; }

    public virtual ICollection<InteractiveCanvas> InteractiveCanvas { get; set; }
}
