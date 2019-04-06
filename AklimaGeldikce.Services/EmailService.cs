using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AklimaGeldikce.Entities;

namespace AklimaGeldikce.Services
{
    public class EmailService : IEmailService, IDisposable
    {
        private readonly SmtpClient smtpClient;

        public EmailService()
        {
            this.smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("hasan.kaplan.me@gmail.com", "password"),
                EnableSsl = true
            };
        }

        public void Dispose()
        {
            this.smtpClient.Dispose();
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            using (var message = new MailMessage())
            {
                message.From = new MailAddress("hasan.kaplan.me@gmail.com", "Hasan Kaplan");
                foreach (var to in emailMessage.To)
                {
                    message.To.Add(new MailAddress(to.Address, to.Name));
                }
                foreach (var bcc in emailMessage.Bcc)
                {
                    message.Bcc.Add(new MailAddress(bcc.Address, bcc.Name));
                }
                foreach (var cc in emailMessage.Cc)
                {
                    message.CC.Add(new MailAddress(cc.Address, cc.Name));
                }
                message.Subject = emailMessage.Subject;
                message.Body = emailMessage.Body;
                message.IsBodyHtml = true;
                
                await this.smtpClient.SendMailAsync(message);
            }
        }
    }
}
