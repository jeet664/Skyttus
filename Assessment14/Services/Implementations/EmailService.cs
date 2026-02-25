using Assessment14.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;

namespace Assessment14.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpSettings> smtpSettings,
                            ILogger<EmailService> logger)
        {
            _smtpSettings = smtpSettings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_smtpSettings.Email);
                email.From.Add(new MailboxAddress(_smtpSettings.DisplayName, _smtpSettings.Email));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;

                var builder = new BodyBuilder
                {
                    HtmlBody = htmlBody
                };

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();

                await smtp.ConnectAsync(
                    _smtpSettings.Host,
                    _smtpSettings.Port,
                    SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(
                    _smtpSettings.Email,
                    _smtpSettings.Password);

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                _logger.LogInformation("Email sent successfully to {Email}", to);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Email sending failed");
                throw;
            }
        }
    }
}