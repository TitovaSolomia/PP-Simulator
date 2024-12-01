using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Animals;

public abstract class Flying : Birds
{
    public override char Symbol
    {
        get { return 'B'; }
    }
    public override void Go(Direction direction)
    {
        Point newPoint = this.Map.Next(this.Position, direction);
        Point newPoint2 = this.Map.Next(newPoint, direction);
        this.Map.Move(this, this.Position, newPoint2);
        this.Position = newPoint2;
    }
}
