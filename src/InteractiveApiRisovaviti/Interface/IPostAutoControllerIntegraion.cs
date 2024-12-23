﻿namespace InteractiveApiRisovaviti.Interface
{
    internal interface IPostAutoControllerIntegraion
    {
        void ExecuteRequest(string url);
        Task ExecuteRequestAsync(string url);
        T2 GetResult<T2>(string url);
    }
}