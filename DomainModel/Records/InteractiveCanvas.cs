
namespace DomainModel.Records
{
    public record class InteractiveCanvas(int Id, string Name, string Descriprion, byte[]? Image, Status Status, User Author);
}
