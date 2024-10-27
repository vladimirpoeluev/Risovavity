using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Model;

[Table("Canvas")]
public partial class Canvas
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; } = null!;

    public int IdStatus { get; set; }

    public int IdAuthor { get; set; }

    public virtual User IdAuthorNavigation { get; set; }

    public virtual Status IdStatusNavigation { get; set; }
}
