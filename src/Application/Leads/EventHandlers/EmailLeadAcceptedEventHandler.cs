using fw.Application.Common.Interfaces;
using fw.Domain.Events;
using Hangfire;
using MediatR;

namespace fw.Application.Leads.EventHandlers;
 
public class EmailLeadAcceptedEventHandler : INotificationHandler<LeadAcceptedEvent>
{    
    private readonly IBackgroundJobClient _jobClient;

    public EmailLeadAcceptedEventHandler(IBackgroundJobClient jobClient)
    {
        _jobClient = jobClient;
    }

    public Task Handle(LeadAcceptedEvent notification, CancellationToken cancellationToken)
    {
        _jobClient.Enqueue<IEmailSender>((x) => x.SendAsync("vendas@test.com", "Lead Notification", "Lead has been accepted!"));
        return Task.CompletedTask;
    }
}