using System;
using TollFeeCalculator;
using Xunit;

public class TollCalculatorTests
{
    [Theory]
    [InlineData(6, 0, 8)]      // 06:00 -> 8 kr
    [InlineData(6, 29, 8)]     // boundary: last minute of the 8 kr band
    [InlineData(6, 30, 13)]    // boundary: first minute of the 13 kr band
    [InlineData(6, 59, 13)]    // boundary: last minute of the 13 kr band
    [InlineData(7, 0, 18)]    // boundary: first minute of the 18 kr band
    [InlineData(7, 59, 18)]    // boundary: last minute of the 18 kr band
    [InlineData(8, 0, 13)]    // boundary: first minute of the 13 kr band
    [InlineData(8, 29, 13)]    // boundary: last minute of the 13 kr band
    [InlineData(8, 30, 8)]    // boundary: first minute of the 8 kr band
    [InlineData(14, 59, 8)]    // boundary: last minute of the 8 kr band
    [InlineData(15, 0, 13)]    // boundary: first minute of the 13 kr band
    [InlineData(15, 29, 13)]    // boundary: last minute of the 13 kr band
    [InlineData(15, 30, 18)]    // boundary: first minute of the 18 kr band
    [InlineData(16, 59, 18)]    // boundary: last minute of the 18 kr band
    [InlineData(17, 0, 13)]    // boundary: first minute of the 13 kr band
    [InlineData(17, 59, 13)]    // boundary: last minute of the 13 kr band
    [InlineData(18, 0, 8)]    // boundary: first minute of the 8 kr band
    [InlineData(18, 29, 8)]    // 	boundary: last minute of the 8 kr band
    [InlineData(18, 30, 0)]    // boundary: first minute of the 0 kr band
    [InlineData(5, 59, 0)]    // boundary: last minute of the 0 kr band

    public void GetTollFee_GivenTimeOfDay_ReturnsExpectedFee(int hour, int minute, int expectedFee)
    {
        var calculator = new TollCalculator();
        var car = new Car();
        var date = new DateTime(2013, 2, 7, hour, minute, 0); // a weekday (Thursday)

        int actualFee = calculator.GetTollFee(date, car);

        Assert.Equal(expectedFee, actualFee);
    }
}