using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)] // Below min
    [InlineData(15, 1, 10, 10)] // Above max
    [InlineData(10, 10, 20, 10)] // At the lower limit
    [InlineData(20, 10, 20, 20)] // At the upper limit
    public void Limiter_ValueWithinBounds_ReturnsClampedValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", "Hello")]
    [InlineData("    multiple   spaces  ", "Multiple   spaces")]
    [InlineData("s", "S##")]
    [InlineData("TooLongOfAString12345622221", "TooLongOfAString123456222")]
    [InlineData(" spaces ", "Spaces")]
    public void Shortener_ValidString_ReturnsFormattedString(string value, string expected)
    {
        var result = Validator.Shortener(value);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_EmptyString_PopulatesWithPlaceholder()
    {
        var result = Validator.Shortener("");

        Assert.Equal("###", result);
    }

    [Theory]
    [InlineData("single", "Single")]
    [InlineData("short", "Short")]
    public void Shortener_MinEqualsMax_ReturnsClampedString(string value, string expected)
    {
        var result = Validator.Shortener(value);

        Assert.Equal(expected, result);
    }
}