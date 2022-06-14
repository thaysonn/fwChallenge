namespace fw.Application.Common.Interfaces;
public interface IEmailSender
{
    Task SendAsync(string email, string subject, string body);
}
