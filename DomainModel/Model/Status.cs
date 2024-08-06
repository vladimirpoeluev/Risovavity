
namespace DomainModel.Model;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Canvas> Canvas { get; set; } = new List<Canvas>();

    public virtual ICollection<InteractiveCanva> InteractiveCanvas { get; set; } = new List<InteractiveCanva>();
}
