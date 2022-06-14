using FluentAssertions;
using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using NUnit.Framework;

namespace fw.Domain.UnitTests.Leads;

public class LeadDiscountTest
{ 
    private ILeadDiscountWorkflow _leadDiscountWorkflow;

    public LeadDiscountTest()
    {
        _leadDiscountWorkflow = new LeadDiscountWorkflow();
    } 

    [Test]
    public void ShouldntApplyDiscount()
    {
        var lead = new Lead("abc", "abc", Price.Of(100), null, null); 
        _leadDiscountWorkflow.Apply(lead); 
        lead.Price.Value.Should().Be(100); 
    }

    [Test]
    public void ShouldApplyDiscount()
    {
        var lead = new Lead("abc", "abc", Price.Of(600), null, null); 
        _leadDiscountWorkflow.Apply(lead); 
        lead.Price.Value.Should().Be(540);

        lead = new Lead("abc", "abc", Price.Of(1000), null, null);
        _leadDiscountWorkflow.Apply(lead);
        lead.Price.Value.Should().Be(900);

        lead = new Lead("abc", "abc", Price.Of(655), null, null);
        _leadDiscountWorkflow.Apply(lead);
        lead.Price.Value.Should().Be(589.50m);
    }
}
