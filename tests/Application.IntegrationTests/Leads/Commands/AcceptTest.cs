using FluentAssertions;
using fw.Application.Common.Exceptions;
using fw.Application.Leads.Commands.Accept;
using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using NUnit.Framework;

namespace fw.Application.IntegrationTests.Leads.Commands;

using static Testing;
internal class AcceptTest : BaseTestFixture
{
    [Test]
    public async Task ShouldThrowNotFoundExceptionWhenTryAcceptLeadWithInvalidId()
    {
        var command = new AcceptCommand(-99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldChangeStatusLeadToAccept()
    {
        var temp = new Lead("YanDerra 2574", "Need to paint 3 aluminum windows and a sliding glass door", Price.Of(62),
                      new Contact() { FirstName = "Bill" },
                      new Category("Interior Painters"));
         
        await AddAsync(temp);
        temp.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        temp.Status.Should().Be(Domain.Enums.LeadStatus.Invited);

        await SendAsync(new AcceptCommand(temp.Id));
         
        var list = await FindAsync<Lead>(temp.Id); 
        list.Should().NotBeNull();  
        list.LastModified.Should().NotBeNull();
        list.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000)); 
        list.Status.Should().Be(Domain.Enums.LeadStatus.Accepted); 
    }

    [Test]
    public async Task ShouldChangeStatusLeadToAcceptAndApplyDiscount()
    {
        var temp = new Lead("YanDerra 2574", "Need to paint 3 aluminum windows and a sliding glass door", Price.Of(501),
                      new Contact() { FirstName = "Bill" },
                      new Category("Interior Painters"));

        await AddAsync(temp);
        await SendAsync(new AcceptCommand(temp.Id));

        var lead = await FindAsync<Lead>(temp.Id);
        lead.Should().NotBeNull();
        lead.Status.Should().Be(Domain.Enums.LeadStatus.Accepted);
        lead.Price.Value.Should().Be(450.9m);
    }
}
