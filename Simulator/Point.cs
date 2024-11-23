using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(X, Y + 1),
            Direction.Down => new Point(X, Y - 1),
            Direction.Left => new Point(X - 1, Y),
            Direction.Right => new Point(X + 1, Y),
            _ => this
        };
    }

    public Point NextDiagonal(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(X + 1, Y + 1),
            Direction.Down => new Point(X - 1, Y - 1),
            Direction.Left => new Point(X - 1, Y + 1),
            Direction.Right => new Point(X + 1, Y - 1),
            _ => this
        };
    }

    public static bool operator ==(Point p1, Point p2)
    {
        return p1.X == p2.X && p1.Y == p2.Y;
    }

    public static bool operator !=(Point p1, Point p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj is Point other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
