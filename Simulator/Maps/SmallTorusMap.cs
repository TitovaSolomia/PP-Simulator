using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }
    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }


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
        int wrappedX = (p.X % Size + Size) % Size;
        int wrappedY = (p.Y % Size + Size) % Size;
        return new Point(wrappedX, wrappedY);
    }

    public override string ToString()
    {
        return $"SmallTorusMap(Size={Size})";
    }
}
