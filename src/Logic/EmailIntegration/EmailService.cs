
using Logic.EmailIntegration.Interface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Logic.EmailIntegration
{
    public class EmailService : IEmailService
	{
		IConfiguration Configuration { get; set; }

		public EmailService(IConfiguration config)
		{
			Configuration = config;
		}
		public async Task SendMessageAsync(string email, string message)
		{
			using MimeMessage messageEntity = new();
			messageEntity.From.Add(new MailboxAddress("Администрация", Configuration["emailAdmin:email"]));
			messageEntity.To.Add(new MailboxAddress(string.Empty, email));

			messageEntity.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};
			await SendMessageAsync(messageEntity);
		}

		public async Task SendMessageAsync(MimeMessage message)
		{
			using SmtpClient smtpClient = new();
			await smtpClient.ConnectAsync("smtp.yandex.ru", 25, false);
			await smtpClient.AuthenticateAsync(Configuration["emailAdmin:email"], Configuration["emailAdmin:password"]);
			await smtpClient.SendAsync(message);

			await smtpClient.DisconnectAsync(true);
		}
	}
}
