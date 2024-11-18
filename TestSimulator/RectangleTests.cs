using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ExceptionCheck()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 2));
    }

    [Fact]
    public void ToString_ReturnsExpectedString()
    {
        var rectangle = new Rectangle(1, 2, 4, 6);
        var result = rectangle.ToString();

        Assert.Equal("(1, 2):(4, 6)", result);
    }

    [Fact]
    public void Contains_PointOutsideRectangle_ReturnsFalse()
    {
        var rectangle = new Rectangle(1, 1, 4, 4);
        var point = new Point(5, 5);

        var result = rectangle.Contains(point);

        Assert.False(result);
    }

    [Fact]
    public void Contains_PointOnEdge_ReturnsTrue()
    {
        var rectangle = new Rectangle(1, 1, 4, 4);
        var point = new Point(1, 3);

        var result = rectangle.Contains(point);

        Assert.True(result);
    }

    [Fact]
    public void Constructor_NegativeCoordinates_CreatesRectangle()
    {
        var rectangle = new Rectangle(-5, -3, -1, -1);

        Assert.Equal(-5, rectangle.x1);
        Assert.Equal(-3, rectangle.y1);
        Assert.Equal(-1, rectangle.x2);
        Assert.Equal(-1, rectangle.y2);
    }

    [Fact]
    public void Contains_PointInsideRectangle_ReturnsTrue()
    {
        var rectangle = new Rectangle(1, 1, 4, 4);
        var point = new Point(2, 3);

        var result = rectangle.Contains(point);

        Assert.True(result);
    }
}
