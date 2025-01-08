using DomainModel.ResultsRequest.EmailResult;

namespace InteractiveApiRisovaviti.Interface
{
    public interface IConfirmationViaEmail
    {
        Task EmailConfimationAsync(EmailConfirmaionResult confirmaion);
        Task<IAuthenticationUser> UserConfimationAsync(UserConfirmationResult confirmation);
    }
}