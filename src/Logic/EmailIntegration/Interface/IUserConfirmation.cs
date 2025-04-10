﻿using DomainModel.JwtModels;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.EmailResult;

namespace Logic.EmailIntegration.Interface
{
    public interface IUserConfirmation
    {
        Task AddToPendingConfirmation(AuthenticationForm form);
        Task<TokensRefreshAndAccess> Verify(UserConfirmationResult userConfirmation);
    }
}