using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TiketAPI.Commons
{
    public class EmailHelper
    {
        private IConfiguration iConfig;
        public EmailHelper(IConfiguration configuration)
        {
            iConfig = configuration;
        }
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var fromEmailAddress = iConfig["FromEmailAddress"].ToString();
            var fromEmailDisplayName = iConfig["FromEmailDisplayName"].ToString();
            var fromEmailPassword = iConfig["FromEmailPassword"].ToString();
            var smtpHost = iConfig["SMTPHost"].ToString();
            var smtpPort = iConfig["SMTPPort"].ToString();
            bool enabledSsl = bool.Parse(iConfig["EnabledSSL"].ToString());
            string body = content;
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}
