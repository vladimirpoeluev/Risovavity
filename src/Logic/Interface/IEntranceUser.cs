using DomainModel.ResultsRequest;

namespace Logic.Interface
{
    public interface IEntranceUser
    {
        Task<UserResult> Login(AuthenticationForm form);
    }
}