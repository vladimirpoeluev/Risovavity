namespace InteractiveApiRisovaviti.Interface
{
    internal interface IGetAutoControllerIntegraion
    {
        T GetResult<T>(string url);
        Task<T> GetResultAsync<T>(string url);
    }
}