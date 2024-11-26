using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Rectangle
{
    public readonly int x1, y1, x2, y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 || y1 == y2)
        {
            throw new ArgumentException("Punkty sa wspolliniowe");
        }

        this.x1 = Math.Min(x1, x2);
        this.y1 = Math.Min(y1, y2);
        this.x2 = Math.Max(x1, x2);
        this.y2 = Math.Max(y1, y2);
    }

    public Rectangle(Point p1, Point p2) 
    {
        this.x1 = p1.X; 
        this.y1 = p1.Y; 
        this.x2 = p2.X; 
        this.y2 = p2.Y;
    }

    public bool Contains(Point point)
    {
        return (point.X >= x1 && point.X <= x2) &&
               (point.Y >= y1 && point.Y <= y2);

    }

    public override string ToString() 
    {
        return ($"({x1}, {y1}):({x2}, {y2})");
    }
}
