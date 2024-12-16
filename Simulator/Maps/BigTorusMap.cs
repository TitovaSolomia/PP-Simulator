using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class BigTorusMap : Map
{
    public int Size { get; }
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => Wrap(new Point(p.X, p.Y + 1)),
            Direction.Down => Wrap(new Point(p.X, p.Y - 1)),
            Direction.Left => Wrap(new Point(p.X - 1, p.Y)),
            Direction.Right => Wrap(new Point(p.X + 1, p.Y)),
            _ => throw new ArgumentException("Invalid direction", nameof(d))
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return d switch
        {
            Direction.Up => Wrap(new Point(p.X + 1, p.Y + 1)),       // Góra w prawo
            Direction.Down => Wrap(new Point(p.X - 1, p.Y - 1)),     // Dół w lewo
            Direction.Left => Wrap(new Point(p.X - 1, p.Y + 1)),     // Góra w lewo
            Direction.Right => Wrap(new Point(p.X + 1, p.Y - 1)),    // Dół w prawo
            _ => throw new ArgumentException("Invalid direction", nameof(d))
        };
    }

    private Point Wrap(Point p)
    {
        int wrappedX = (p.X % SizeX + SizeX) % SizeX;
        int wrappedY = (p.Y % SizeY + SizeY) % SizeY;
        return new Point(wrappedX, wrappedY);
    }

    public override string ToString()
    {
        return $"SmallTorusMap(Size={Size})";
    }
}
