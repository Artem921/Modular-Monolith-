using Microsoft.Extensions.Options;
using Notification.Domain.Abstraction;
using Notification.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace Notification.Infrastructure
{
    internal class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;
        private readonly SmtpClient client;

        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;

            client = new SmtpClient(_emailOptions.Server, _emailOptions.Port);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailOptions.Email, _emailOptions.Password);
            client.EnableSsl = true;
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var from = new MailAddress(_emailOptions.Email, _emailOptions.FromName);
            var to = new MailAddress(email);
            var message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;

            await client.SendMailAsync(message);
        }

    }
}
