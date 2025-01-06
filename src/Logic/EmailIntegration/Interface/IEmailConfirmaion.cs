using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.EmailResult;

namespace Logic.EmailIntegration.Interface
{
    public interface IEmailConfirmaion
    {
        Task AddToPendingConfirmation(RegistrationForm registrationForm);
        Task Valid(EmailConfirmaionResult confirmaion);
    }
}