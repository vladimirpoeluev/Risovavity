namespace Logic.Interface
{
    public interface IEntrance
    {
        string EntranceInSystem(string login, string password);
        Task<string> EntranceInSystemAsync(string login, string password);
    }
}
