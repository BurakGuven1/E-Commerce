using BusinessLayer.Abstract;
using Entities.DTOs;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace BusinessLayer.Concrete
{
    public class EmailManager : IEmailService
    {
        public void SendEmail(Users[] users, string subject,string body)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse("yyokyokk9@gmail.com"));

            foreach (var user in users)
            {
                email.To.Add(MailboxAddress.Parse(user.Email));
            }
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = body};
            // email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("yyokyokk9@gmail.com", "oxvmkenegknrmkai");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
