namespace InteractiveApiRisovaviti.Interface
{
    internal interface IGetAutoControllerIntegraion
    {
        T GetResult<T>(string url);
    }
}