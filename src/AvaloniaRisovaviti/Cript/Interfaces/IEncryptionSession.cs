using InteractiveApiRisovaviti.Interface;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Cript.Interfaces
{
    internal interface IEncryptionSession
    {
        Task<IAuthenticationUser> GetSessionAsync();
        Task SetSessionAsync(string sessionName);
        bool TryGetSession(out IAuthenticationUser session);
    }
}