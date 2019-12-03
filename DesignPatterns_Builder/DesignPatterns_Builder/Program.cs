using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DesignPatterns_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Builder!");

            var mail = new MailMessageBuilder()
                .From("a.miroshkin@mxmgt.com")
                .To("anton.miroshkin@mxmgt.com")
                .Cc("mag1986@list.ru")
                .Subject("Test message")
                .IsBodyHtml(false)
                .Body("Test message body", Encoding.UTF8)
                .Build();


        }
    }

    public sealed class MailMessageBuilder
    {
        private readonly MailMessage _mailMessage = new MailMessage();

        public MailMessageBuilder From(string address)
        {
            _mailMessage.From = new MailAddress(address);
            return this;
        }

        public MailMessageBuilder To(string address)
        {
            _mailMessage.To.Add(address);
            return this;
        }

        public MailMessageBuilder Cc(string address)
        {
            _mailMessage.CC.Add(address);
            return this;
        }

        public MailMessageBuilder Subject(string subject)
        {
            _mailMessage.Subject = subject;
            return this;
        }

        public MailMessageBuilder Body(string body, Encoding encoding)
        {
            _mailMessage.Body = body;
            _mailMessage.BodyEncoding = encoding;
            return this;
        }

        public MailMessageBuilder IsBodyHtml(bool isBodyHtml)
        {
            _mailMessage.IsBodyHtml = isBodyHtml;
            return this;
        }

        public MailMessage Build()
        {
            return _mailMessage;
        }


    }
}
