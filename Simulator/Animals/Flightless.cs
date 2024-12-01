using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Animals;

public abstract class Flightless : Birds
{
    public override char Symbol
    {
        get { return 'b'; }
    }
    public override void Go(Direction direction)
    {
        Point newPoint = this.Map.NextDiagonal(this.Position, direction);
        this.Map.Move(this, this.Position, newPoint);
        this.Position = newPoint;
    }
}
