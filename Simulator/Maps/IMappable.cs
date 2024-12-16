using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public interface IMappable
{
    Map? Map { get; }

    Point Position { get; }

    abstract char Symbol { get; }

    public void Go(Direction currentMove);
    public void InitMapAndPosition(Map map, Point point);
    public string ToString();
}
