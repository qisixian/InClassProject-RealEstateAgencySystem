using Microsoft.AspNetCore.Identity.UI.Services;
using RealEstateAgencySystem.Models;
using System.Threading.Tasks;
namespace RealEstateAgencySystem.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}