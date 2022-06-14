using FluentAssertions; 
using fw.Application.Leads.Queries.GetLeads.GetAcceptedLeads;
using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using NUnit.Framework;

namespace fw.Application.IntegrationTests.Leads.Queries;

using static Testing;

public class GetAcceptedLeadsQueryTest : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllAcceptedLeads()
    {
        await AddAsync(new Lead("YanDerra 2574", "Need to paint...", Price.Of(62),
            new Contact()
            {
                FirstName = "Bill"
            },
            new Category("Interior Painters")).Accept());
        await AddAsync(new Lead("Carramar 6031", "Plaster exposed brick walls (see photos), square off 2 archways (see photos), and expand pantry (see photos).", Price.Of(26),
                new Contact()
                {
                    FirstName = "Pete",
                    LastName = "Sanderson",
                    PhoneNumber = "0412345678",
                    Email = "fake@maillinator.com"
                },
                new Category("General Building Work")));

        var result = await SendAsync(new GetAcceptedLeadsQuery());

        result.Should().HaveCount(1);
        result.First().Suburb.Should().Be("YanDerra 2574");
        result.First().Description.Should().Be("Need to paint...");
        result.First().Contact.FirstName.Should().Be("Bill");
        result.First().Category.Should().Be("Interior Painters");
        result.First().Status.Should().Be(Domain.Enums.LeadStatus.Accepted);
    }
}