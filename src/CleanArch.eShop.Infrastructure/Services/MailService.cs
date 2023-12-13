using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Application.Common.Models;
using CleanArch.eShop.Infrastructure.Configurations;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CleanArch.eShop.Infrastructure.Services
{
    public class MailService(IOptions<MailSettings> mailSettingsOptions) : IMailService
    {
        private readonly MailSettings _mailSettings = mailSettingsOptions.Value;
        public async Task<bool> SendMailAsync(MailData mailData)
        {
            try
            {
                using MimeMessage emailMessage = new();
                MailboxAddress emailFrom = new(_mailSettings.SenderName, _mailSettings.SenderEmail);
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new(mailData.EmailToName, mailData.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                emailMessage.Subject = mailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new()
                {
                    TextBody = mailData.EmailBody
                };

                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                using SmtpClient mailClient = new();
                await mailClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                await mailClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                await mailClient.SendAsync(emailMessage);
                await mailClient.DisconnectAsync(true);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
