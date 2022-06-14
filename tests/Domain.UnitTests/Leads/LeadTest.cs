using FluentAssertions;
using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using NUnit.Framework;

namespace fw.Domain.UnitTests.Leads;

public class LeadTest
{
    [Test]
    public void ShouldThrowArgumentExceptionWhenTryToCreateALeadWithPriceNull()
    {
        FluentActions.Invoking(() => new Lead("abc", "abc", null, null, null))
           .Should().Throw<ArgumentException>();
    }

    [Test]
    public void ShouldCreateAValidLead()
    {
        var lead = new Lead("YanDerra 2574", "Need to paint 3 aluminum windows and a sliding glass door", Price.Of(89),
            new Contact()
            {
                FirstName = "Chris",
                LastName = "Sanderson",
                PhoneNumber = "04987654321",
                Email = "another.fake@hipmail.com"
            },
            new Category("Home Renovations"));

        lead.Price.Value.Should().Be(89);
        lead.Suburb.Should().Be("YanDerra 2574");
        lead.Description.Should().Be("Need to paint 3 aluminum windows and a sliding glass door");
        lead.Contact.FirstName.Should().Be("Chris");
        lead.Contact.LastName.Should().Be("Sanderson");
        lead.Contact.FullName.Should().Be("Chris Sanderson");
        lead.Contact.PhoneNumber.Should().Be("04987654321");
        lead.Contact.Email.Should().Be("another.fake@hipmail.com");
        lead.Category.Description.Should().Be("Home Renovations");
        lead.Status.Should().Be(Enums.LeadStatus.Invited);
    }
}
