namespace Logic.Interface
{
    public interface IEntrance
    {
        Guid EntranceInSystem(string login, string password);
        Task<Guid> EntranceInSystemAsync(string login, string password);
    }
}
