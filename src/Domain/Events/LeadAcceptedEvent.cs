namespace fw.Domain.Events;

public class LeadAcceptedEvent : BaseEvent
{
    public LeadAcceptedEvent(Lead lead) => Lead = lead;
    public Lead Lead { get; }
}
