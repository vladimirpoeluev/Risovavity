namespace InteractiveApiRisovaviti.Interface
{
    internal interface IPostAutoControllerIntegraion
    {
        void ExecuteReques(string url);
        T2 GetResult<T2>(string url);
    }
}