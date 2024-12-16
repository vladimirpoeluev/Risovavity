namespace InteractiveApiRisovaviti.Interface
{
    public interface IGetAutoControllerIntegraion
    {
        T GetResult<T>(string url);
        Task<T> GetResultAsync<T>(string url);
    }
}