namespace LBTT_Calculator.Tests;

using NUnit.Framework;
using LBTT_Calculator;

[TestFixture]
public class ResidentalTests
{
    private LBTTCalculator calculator;

    [SetUp]
    public void SetUp()
    {
        List<ITaxBandStrategy> taxBrackets = new List<ITaxBandStrategy>
            {
                new StandardTaxBandStrategy(0, 145000, 0.00m),
                new StandardTaxBandStrategy(145000, 250000, 0.02m),
                new StandardTaxBandStrategy(250000, 325000, 0.05m),
                new StandardTaxBandStrategy(325000, 750000, 0.1m),
                new UpperTaxBandStrategy(750000, 0.12m)
            };
        calculator = new LBTTCalculator(taxBrackets);
    }

    [Test]
    public void TestPropertyValue145000ReturnsZero()
    {
        int propertyValue = 145000;
        decimal expectedTax = 0;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }

    [Test]
    public void TestSecondBandPropertyValueReturns2PercentTax()
    {
        int propertyValue = 150000;
        decimal expectedTax = 100;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }

    [Test]
    public void TestThirdBandPropertyValueReturns5PercentTax()
    {
        int propertyValue = 300000;
        decimal expectedTax = 4600;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }

    [Test]
    public void TestFourthBandPropertyValueReturns10PercentTax()
    {
        int propertyValue = 550000;
        decimal expectedTax = 28350;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }

    [Test]
    public void TestUpperBandPropertyValueReturns12PercentTax()
    {
        int propertyValue = 800000;
        decimal expectedTax = 54350;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }
}


[TestFixture]
public class NonResidentalTests
{
    private LBTTCalculator calculator;

    [SetUp]
    public void SetUp()
    {
        List<ITaxBandStrategy> taxBrackets = new List<ITaxBandStrategy>
            {
                new StandardTaxBandStrategy(0, 150000, 0.00m),
                new StandardTaxBandStrategy(150000, 250000, 0.01m),
                new UpperTaxBandStrategy(250000, 0.05m)
            };
        calculator = new LBTTCalculator(taxBrackets);
    }

    [Test]
    public void TestPropertyValue145000ReturnsZero()
    {
        int propertyValue = 145000;
        decimal expectedTax = 0;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }

    [Test]
    public void TestSecondBandPropertyValueReturns1PercentTax()
    {
        int propertyValue = 170000;
        decimal expectedTax = 200;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }

    [Test]
    public void TestUpperBandPropertyValueReturns5PercentTax()
    {
        int propertyValue = 465000;
        decimal expectedTax = 11750;

        decimal gotTax = calculator.CalculateTax(propertyValue);

        Assert.That(gotTax, Is.EqualTo(expectedTax));
    }
}