using OzhanHr.Application.Model;

namespace OzhanHr.Application.Contracts.Infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}