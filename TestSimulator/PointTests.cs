using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void ToString_ValidString()
    {
        Point point = new Point(5, 5);
        Assert.Equal("(5, 5)", point.ToString());
    }

    [Theory]
    [InlineData(3, 4, Direction.Right, 4, 4)]
    [InlineData(3, 4, Direction.Up, 3, 5)]
    [InlineData(3, 4, Direction.Left, 2, 4)]
    [InlineData(3, 4, Direction.Down, 3, 3)]
    public void Next_ShouldReturnCorrectValue(int xStart, int yStart, Direction direction, int xEnd, int yEnd)
    {
        Point start = new Point(xStart, yStart);
        Point end = new Point(xEnd, yEnd);

        Assert.Equal(end, start.Next(direction));
    }

    [Theory]
    [InlineData(3, 4, Direction.Right, 4, 3)]
    [InlineData(3, 4, Direction.Up, 4, 5)]
    [InlineData(3, 4, Direction.Left, 2, 5)]
    [InlineData(3, 4, Direction.Down, 2, 3)]
    public void NextDiagonal_ShouldReturnCorrectValue(int xStart, int yStart, Direction direction, int xEnd, int yEnd)
    {
        Point start = new Point(xStart, yStart);
        Point end = new Point(xEnd, yEnd);

        Assert.Equal(end, start.NextDiagonal(direction));
    }
}