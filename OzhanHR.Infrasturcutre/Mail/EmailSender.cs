using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OzhanHr.Application.Contracts.Infrastructure;
using OzhanHr.Application.Model;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OzhanHR.Infrasturcutre.Mail
{
    public class EmailSender : IEmailSender
    {
        //This Is How To Create Email With SendGrid Library 

        private readonly EmailSettings _setting;
        public EmailSender(IOptions<EmailSettings> setting)
        {
            _setting = setting.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_setting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress()
            {
                Email = _setting.FromAddress,
                Name = _setting.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK ||
                   response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
