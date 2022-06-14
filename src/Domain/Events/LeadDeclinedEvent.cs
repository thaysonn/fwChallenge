namespace fw.Domain.Events;

public class LeadDeclinedEvent : BaseEvent
{
    public LeadDeclinedEvent(Lead lead) => Lead = lead;
    public Lead Lead { get; }
}