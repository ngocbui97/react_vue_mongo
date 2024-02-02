using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace JobVietAPI.Commons
{
    public class EmailHelper
    {
        public static async Task SendMail(IConfiguration _config, string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = _config["FromEmailAddress"].ToString();
            var fromEmailDisplayName = _config["FromEmailDisplayName"].ToString();
            var fromEmailPassword = _config["FromEmailPassword"].ToString();
            var smtpHost = _config["SMTPHost"].ToString();
            var smtpPort = _config["SMTPPort"].ToString();
            bool enabledSsl = bool.Parse(_config["EnabledSSL"].ToString());

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = content;

            var client = new SmtpClient();
            //client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;

            client.Send(message);
        }
    }
}
