namespace fw.Domain.Leads;
public class LeadDiscountWorkflow : ILeadDiscountWorkflow
{
    public void Apply(Lead lead)
    {
        if (lead.Price > 500)
        {
            lead.ApplyDiscount(10);
        }
    }
}
