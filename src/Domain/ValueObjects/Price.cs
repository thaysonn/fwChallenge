namespace fw.Domain.ValueObjects;
public class Price
{
    private Price() { }

    public Price(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public static Price Of(decimal value)
    {
        if (value < 0) throw new ArgumentException("Price amount value cannot be negative."); 
        return new Price(value);
    }

    public static Price operator *(Price leftValue, decimal number)
    {
        return new Price(leftValue.Value * number);
    }

    public static Price operator -(Price rightValue, Price leftValue)
    {
        return new Price(rightValue.Value - leftValue.Value);
    }

    public static Price operator -(Price leftValue, decimal Value)
    {
        return new Price(leftValue.Value - Value);
    }

    public static bool operator >(Price rightValue, decimal leftValue)
    {
        return rightValue.Value > leftValue;
    }

    public static bool operator <(Price rightValue, decimal leftValue)
    {
        return rightValue.Value < leftValue;
    }
}
