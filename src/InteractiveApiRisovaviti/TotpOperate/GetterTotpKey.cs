using DomainModel.Integration.TotpOperation;
using DomainModel.ResultsRequest.TotpModels;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Interface.Topt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InteractiveApiRisovaviti.TotpOperate
{
    public class GetterTotpKey : IGetterTotp
    {
        IGetAutoControllerIntegraion controllerIntegraion;
        public GetterTotpKey(FabricAutoControllerIntegraion fabricAuto,
                                IAuthenticationUser user)
        {
            controllerIntegraion = fabricAuto.CreateGetPatser(user);
        }
        public Task<TotpKeysResult> GetKey()
        {
            return controllerIntegraion.GetResultAsync<TotpKeysResult>("api/restore-access/key");
        }
    }
}
