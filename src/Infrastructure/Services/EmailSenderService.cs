using fw.Application.Common.Interfaces;

namespace fw.Infrastructure.Services;
public class EmailSenderService : IEmailSender
{
    public async Task SendAsync(string email, string subject, string body)
    {
        await Task.Delay(1000);
        Console.WriteLine("Email has been sent!"); 
    }
}
