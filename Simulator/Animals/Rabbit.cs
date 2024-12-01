using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Animals;

public class Rabbit : Animals
{
    public override void Go(Direction currentMove)
    {
        Point newPoint = this.Map.Next(this.Position, currentMove);
        this.Map.Move(this, this.Position, newPoint);
        this.Position = newPoint;
    }
}
