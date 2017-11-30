using System;
using System.IO;
using System.Linq;
using MailKit.Net.Smtp;
using MailKitTest.Config;
using MailKitTest.Model;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace MailKitTest
{
    class Program
    {
        static string _line = string.Empty;
        static IEmailConfiguration _config;
        public static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings.json", optional: true);
            Configuration = builder.Build();

            _config = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            while (_line != "q")
            {
                SendEmail();                

                Console.WriteLine("type the command: q - quit, mailto:mail@example.com:subject:text - send email");
                ReadLine();
            }
        }

        private static void SendEmail()
        {

            var slices = _line.Split(":");
            if (slices.Length == 4)
            {
                var emailMessage = new EmailMessage();
                emailMessage.Content = slices[3];
                emailMessage.Subject = slices[2];
                emailMessage.ToAddresses.Add(new EmailAddress { Address = slices[1], Name = "Mail Receiver" });
                // CC
                emailMessage.ToAddresses.Add(new EmailAddress { Address = "rr@extracode.com.ua", Name = "Roman Romanchuk" });
                emailMessage.FromAddresses.Add(new EmailAddress { Address = "mail.sender@concoleapp.edu", Name = "Mail Sender" });

                SendEmail(emailMessage);

                Console.WriteLine("your email was sent!");

            }
        }

        private static void SendEmail(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                //The last parameter here is to use SSL (Which you should!)
                emailClient.Connect(_config.SmtpServer, _config.SmtpPort, true);

                //Remove any OAuth functionality as we won't be using it. 
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                emailClient.Authenticate(_config.SmtpUsername, _config.SmtpPassword);

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }

        }

        private static void ReadLine()
        {
            _line = Console.ReadLine();
        }
    }
}
