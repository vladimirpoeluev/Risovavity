
namespace DomainModel.Model;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Canvas> Canvas { get; set; }

    public virtual ICollection<InteractiveCanvas> InteractiveCanvas { get; set; }
}
