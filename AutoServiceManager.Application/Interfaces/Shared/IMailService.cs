using AutoServiceManager.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace AutoServiceManager.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}