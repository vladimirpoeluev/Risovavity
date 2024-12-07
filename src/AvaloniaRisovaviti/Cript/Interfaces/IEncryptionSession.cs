using InteractiveApiRisovaviti.Interface;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Cript.Interfaces
{
    internal interface IEncryptionSession
    {
        Task<IAuthenticationUser> GetSessionAsync();
        Task SetSessionAsync(IAuthenticationUser session);
        bool TryGetSession(out IAuthenticationUser session);
    }
}