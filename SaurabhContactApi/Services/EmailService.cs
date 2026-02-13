using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace SaurabhContactApi.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var emailSettings = _config.GetSection("EmailSettings");
            var fromEmail = emailSettings["FromEmail"];
            var smtpServer = emailSettings["SmtpServer"];
            var port = int.Parse(emailSettings["Port"]);
            var username = emailSettings["Username"];
            var password = emailSettings["Password"];

            using (var client = new SmtpClient(smtpServer, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(username, password);

                var mailMessage = new MailMessage(fromEmail, toEmail, subject, body);
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
        }
    }
}
