
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
			messageEntity.From.Add(new MailboxAddress("Техническая служба \"Рисовавити\"", Configuration["emailAdmin:email"]));
			messageEntity.To.Add(new MailboxAddress(string.Empty, email));

			messageEntity.Subject = "Подтверждение почты";
			messageEntity.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = message
			};
			await SendMessageAsync(messageEntity);
		}

		public async Task SendMessageAsync(MimeMessage message)
		{
			try
			{
				using SmtpClient smtpClient = new();
				await smtpClient.ConnectAsync(	Configuration["emailAdmin:service:address"], 
												int.Parse(Configuration["emailAdmin:service:port"] ?? "465"),
												bool.Parse(Configuration["emailAdmin:service:usessl"] ?? "true"));
				var login = Configuration["emailAdmin:login"];
				var password = Configuration["emailAdmin:password"];
				smtpClient.Authenticate(login, password);
				await smtpClient.SendAsync(message);

				await smtpClient.DisconnectAsync(true);
			}
			catch (Exception ex) 
			{

			}
			
		}
	}
}
