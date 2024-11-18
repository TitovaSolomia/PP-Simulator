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
    [InlineData("hello", 3, 10, '-', "Hello")]
    [InlineData("    multiple   spaces  ", 5, 20, '*', "Multiple   spaces")]
    [InlineData("short", 10, 15, '*', "Short*****")]
    [InlineData("TooLongOfAString", 5, 10, '-', "TooLongOfA")]
    [InlineData(" spaces ", 2, 8, '#', "Spaces")]
    public void Shortener_ValidString_ReturnsFormattedString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_EmptyString_PopulatesWithPlaceholder()
    {
        var result = Validator.Shortener("", 5, 10, '-');

        Assert.Equal("-----", result);
    }

    [Theory]
    [InlineData("single", 6, 6, '*', "Single")]
    [InlineData("short", 5, 5, '-', "Short")]
    public void Shortener_MinEqualsMax_ReturnsClampedString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);

        Assert.Equal(expected, result);
    }
}