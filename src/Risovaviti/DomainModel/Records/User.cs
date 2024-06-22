
namespace DomainModel.Records
{
    public record class User(int Id, string Name, string Email, string Login, string Password, Role Role, byte[]? Icon);
}
