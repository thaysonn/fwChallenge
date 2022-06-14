using fw.Domain.ValueObjects;
using FluentAssertions;
using NUnit.Framework;

namespace fw.Domain.UnitTests.ValueObjects;

public class PriceTests
{ 
    [Test]
    public void ShouldCompareTwoValues()
    {
        Assert.IsTrue(new Price(110) > 100);
        Assert.IsFalse(new Price(10) > 1000);
        Assert.IsTrue(new Price(101) > 100);
        Assert.IsFalse(new Price(55) > 55);
        Assert.IsFalse(new Price(110) < 100);
        Assert.IsTrue(new Price(10) < 1000);
        Assert.IsFalse(new Price(101) < 100);
        Assert.IsFalse(new Price(55) < 55);
    }

    [Test]
    [TestCase(100, 10, 90)]
    [TestCase(33, 1, 32)]
    [TestCase(153, 100, 53)]
    [TestCase(1864.36, 9, 1855.36)]
    public void ShouldSubstractTwoPricesObjectValue(decimal input, decimal substract, decimal expected)
    {
        Price result = new Price(input) - new Price(substract);
        result.Value.Should().Be(expected);
    }

    [Test]
    [TestCase(100, 10, 90)]
    [TestCase(33, 1, 32)]
    [TestCase(153, 100, 53)]
    [TestCase(1864.36, 9, 1855.36)]
    public void ShouldSubstractPriceValueAndDecimal(decimal input, decimal substract, decimal expected)
    {
        Price result = new Price(input) - substract;
        result.Value.Should().Be(expected);
    }

    [Test]
    [TestCase(60, 3, 180)]
    [TestCase(33, 100, 3300)]
    [TestCase(153, 3, 459)]
    [TestCase(154.36, 9, 1389.24)]
    public void ShouldMultiply(decimal input, int multiply, decimal expected)
    {
        Price result = Price.Of(input) * multiply;
        result.Value.Should().Be(expected);
    }

    [Test]
    public void ShouldCreateANewValue()
    {
        Price price = Price.Of(65); 
        price.Value.Should().Be(65);
    }

    [Test]
    public void ShouldThrowArgumentExceptionGivenNotSupportedValue()
    {
        FluentActions.Invoking(() => Price.Of(-1))
            .Should().Throw<ArgumentException>();
    }
}