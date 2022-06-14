using fw.Domain.ValueObjects;

namespace fw.Domain.Leads;
public class Lead : BaseAuditableEntity
{
    private Lead() { } 
    public Lead(string? suburb, string? description, Price price, Contact contact, Category category)
    {
        Suburb = suburb;
        Description = description;
        Price = price ?? throw new ArgumentException("Lead price cannot be null or whitespace.");
        Contact = contact;
        Category = category;
        Created = DateTime.Now;
    }

    public string? Suburb { get; private set; }
    public string? Description { get; private set; }
    public Price Price { get; private set; }
    public LeadStatus Status { get; private set; } = LeadStatus.Invited;
    public Contact Contact { get; private set; } = null!;
    public Category Category { get; private set; } = null!;
     
    public Lead Decline()
    {
        Status = LeadStatus.Declined;
        AddDomainEvent(new LeadDeclinedEvent(this));
        return this;
    }

    public Lead Accept()
    {
        Status = LeadStatus.Accepted;
        AddDomainEvent(new LeadAcceptedEvent(this));
        return this;
    }

    internal void ApplyDiscount(int percent)
    {
        var discount = this.Price * (percent / 100m); 
        this.Price -= discount;
    }
} 