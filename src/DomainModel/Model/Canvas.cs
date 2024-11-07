using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Model;

[Table("Canvas")]
public partial class Canvas
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int StatusId { get; set; }

    public int AuthorId { get; set; }

    public virtual User Author { get; set; }

    public virtual Status Status { get; set; }

    public virtual VersionProject MainVersion { get; set; }

}
