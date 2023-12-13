using CleanArch.eShop.Application.Common.Models;

namespace CleanArch.eShop.Application.Common.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(MailData mailData);
    }
}
