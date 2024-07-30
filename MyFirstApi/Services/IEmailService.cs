using MyFirstApi.Models;

namespace MyFirstApi.Services;

public interface IEmailService
{
    (string to, string subject, string body) GenerateInvoiceEmail(Invoice invoice);
    Task SendEmailAsync(string to, string subject, string body);
}