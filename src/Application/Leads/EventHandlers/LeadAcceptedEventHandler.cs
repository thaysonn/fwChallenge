using fw.Application.Common.Interfaces;
using fw.Domain.Events;
using fw.Domain.Leads;
using MediatR;

namespace fw.Application.Leads.EventHandlers;

public class LeadAcceptedEventHandler : INotificationHandler<LeadAcceptedEvent>
{    
    private readonly ILeadDiscountWorkflow _leadDiscountWorkflow;
    private readonly IApplicationDbContext _context;

    public LeadAcceptedEventHandler(ILeadDiscountWorkflow leadDiscountWorkflow, IApplicationDbContext context)
    { 
        _leadDiscountWorkflow = leadDiscountWorkflow;
        _context = context;
    }

    public async Task Handle(LeadAcceptedEvent notification, CancellationToken cancellationToken)
    { 
        _leadDiscountWorkflow.Apply(notification.Lead);
        await _context.SaveChangesAsync(cancellationToken); 
    }
}
