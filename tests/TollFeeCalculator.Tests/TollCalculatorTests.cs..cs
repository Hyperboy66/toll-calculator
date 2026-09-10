using System;
using TollFeeCalculator;
using Xunit;

public class TollCalculatorTests
{
    [Theory]
    [InlineData(6, 0, 8)]      // 06:00 -> 8 kr
    [InlineData(6, 29, 8)]     // gränsvärde: sista minuten i 8kr-bandet
    [InlineData(6, 30, 13)]    // gränsvärde: första minuten i 13kr-bandet
    [InlineData(6, 59, 13)]    // gränsvärde: sista minuten i 13kr-bandet
    [InlineData(7, 0, 18)]    // gränsvärde: första minuten i 18kr-bandet
    [InlineData(7, 59, 18)]    // gränsvärde: sista minuten i 18kr-bandet
    [InlineData(8, 0, 13)]    // gränsvärde: första minuten i 13kr-bandet
    [InlineData(8, 29, 13)]    // gränsvärde: sista minuten i 13kr-bandet
    [InlineData(8, 30, 8)]    // gränsvärde: första minuten i 8kr-bandet
    [InlineData(14, 59, 8)]    // gränsvärde: sista minuten i 8kr-bandet
    [InlineData(15, 0, 13)]    // gränsvärde: första minuten i 13kr-bandet
    [InlineData(15, 29, 13)]    // gränsvärde: sista minuten i 13kr-bandet
    [InlineData(15, 30, 18)]    // gränsvärde: första minuten i 18kr-bandet
    [InlineData(16, 59, 18)]    // gränsvärde: sista minuten i 18kr-bandet
    [InlineData(17, 0, 13)]    // gränsvärde: första minuten i 13kr-bandet
    [InlineData(17, 59, 13)]    // gränsvärde: sista minuten i 13kr-bandet
    [InlineData(18, 0, 8)]    // gränsvärde: första minuten i 8kr-bandet
    [InlineData(18, 29, 8)]    // gränsvärde: sista minuten i 8kr-bandet
    [InlineData(18, 30, 0)]    // gränsvärde: första minuten i 0kr-bandet
    [InlineData(5, 59, 0)]    // gränsvärde: sista minuten i 0kr-bandet

    public void GetTollFee_GivenTimeOfDay_ReturnsExpectedFee(int hour, int minute, int expectedFee)
    {
        var calculator = new TollCalculator();
        var car = new Car();
        var date = new DateTime(2013, 2, 7, hour, minute, 0); // en vardag (torsdag)

        int actualFee = calculator.GetTollFee(date, car);

        Assert.Equal(expectedFee, actualFee);
    }
}