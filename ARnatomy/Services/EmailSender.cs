using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Threading.Tasks;

namespace ARnatomy.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ARnatomy", _configuration["SmtpSettings:From"]));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();

            try
            {
                var smtpHost = _configuration["SmtpSettings:Host"];
                var smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);
                var smtpUser = _configuration["SmtpSettings:Username"];
                var smtpPass = _configuration["SmtpSettings:Password"];

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(smtpUser, smtpPass);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("MailKit email sending failed: " + ex.Message);
            }
        }
    }
}

