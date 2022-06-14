using FluentAssertions;
using fw.Application.Leads.Queries.GetOptions;
using NUnit.Framework;

namespace fw.Application.IntegrationTests.Leads.Queries;

using static Testing;

public class GetOptionsQueryTest : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnOptionsLeads()
    { 
        var result = await SendAsync(new GetOptionsLeadQuery());         
        result.Should().NotBeEmpty();
    }
}