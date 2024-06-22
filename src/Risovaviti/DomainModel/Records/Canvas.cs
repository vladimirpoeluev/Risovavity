namespace DomainModel.Records
{
    public record class Canvas(int Id, string Name, string Descriprion, byte[]? Image, Status Status, User Author);
}
