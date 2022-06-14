using FluentAssertions;
using fw.Application.Common.Exceptions; 
using fw.Application.Leads.Commands.Decline;
using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using NUnit.Framework;

namespace fw.Application.IntegrationTests.Leads.Commands;

using static Testing;
internal class DeclineTest : BaseTestFixture
{
    [Test]
    public async Task ShouldThrowNotFoundExceptionWhenTryDeclineLeadWithInvalidId()
    {
        var command = new DeclineCommand(100);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldChangeStatusLeadToDecline()
    {
        var temp = new Lead("YanDerra 2574", "Need to paint 3 aluminum windows and a sliding glass door", Price.Of(52),
                      new Contact() { FirstName = "Bill" },
                      new Category("Interior Painters"));

        await AddAsync(temp); 
        temp.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        temp.Status.Should().Be(Domain.Enums.LeadStatus.Invited);

        await SendAsync(new DeclineCommand(temp.Id)); 
        var leadCreated = await FindAsync<Lead>(temp.Id);
        leadCreated.Should().NotBeNull();
        leadCreated.LastModified.Should().NotBeNull();
        leadCreated.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000)); 
        leadCreated.Status.Should().Be(Domain.Enums.LeadStatus.Declined);
    }
}
