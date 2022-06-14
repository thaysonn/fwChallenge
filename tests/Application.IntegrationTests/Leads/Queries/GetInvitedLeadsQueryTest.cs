using FluentAssertions; 
using fw.Application.Leads.Queries.GetLeads.GetInvitedLeads;
using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using NUnit.Framework;

namespace fw.Application.IntegrationTests.Leads.Queries;

using static Testing;

public class GetInvitedLeadsQueryTest : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnAllInvitedLeads()
    {
        await AddAsync(new Lead("YanDerra 2574", "Need to paint...", Price.Of(62),
                 new Contact()
                 {
                     FirstName = "Bill"
                 },
                 new Category("Interior Painters")).Accept());

        await AddAsync(new Lead("Carramar 6031", "Plaster exposed brick walls (see photos)..", Price.Of(68),
                new Contact()
                {
                    FirstName = "Pete",
                    LastName = "Sanderson",
                    PhoneNumber = "0412345678",
                    Email = "fake@maillinator.com"
                },
                new Category("General Building Work")));

        var result = await SendAsync(new GetInvitedLeadsQuery());

        result.Should().HaveCount(1);
        result.First().Suburb.Should().Be("Carramar 6031");
        result.First().Description.Should().Be("Plaster exposed brick walls (see photos)..");
        result.First().Category.Should().Be("General Building Work");
        result.First().Contact.FullName.Should().Be("Pete Sanderson");
        result.First().Contact.FirstName.Should().Be("Pete");
        result.First().Contact.LastName.Should().Be("Sanderson");
        result.First().Contact.PhoneNumber.Should().Be("0412345678");
        result.First().Contact.Email.Should().Be("fake@maillinator.com");
        result.First().Price.Should().Be(68);
        result.First().Status.Should().Be(Domain.Enums.LeadStatus.Invited);
    }
}
