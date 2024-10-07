

namespace DomainModel.Model;

public partial class InteractiveCanvas
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? ConnectionString { get; set; } 

    public int IdStatus { get; set; }

    public int Author { get; set; }

    public virtual User AuthorNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
