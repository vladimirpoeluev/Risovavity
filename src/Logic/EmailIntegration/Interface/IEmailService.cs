using MimeKit;

namespace Logic.EmailIntegration.Interface
{
    public interface IEmailService
    {
        Task SendMessageAsync(MimeMessage message);
        Task SendMessageAsync(string email, string message);
    }
}