using NUnit.Framework;

namespace fw.Application.IntegrationTests;

using static Testing;

[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp() => await ResetState();
}
