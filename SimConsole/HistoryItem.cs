using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class HistoryItem
{
    public Dictionary<Point, List<IMappable>> mapState { get; private set; }
    public IMappable actualCharacter { get; private set; }
    public Direction actualDirection { get; private set; }  

    public HistoryItem (IMappable actualCharacter, Direction actualDirection, Dictionary<Point, List<IMappable>> mapState) 
    { 
        this.actualCharacter = actualCharacter;
        this.actualDirection = actualDirection;
        this.mapState = this.CopyMapState(mapState);  
    }

    private Dictionary<Point, List<IMappable>> CopyMapState(Dictionary<Point, List<IMappable>> mapState)
    {
        var deepCopy = new Dictionary<Point, List<IMappable>>();

        foreach (var kvp in mapState)
        {
            Point keyCopy = new Point(kvp.Key.X, kvp.Key.Y);

            var valueListCopy = new List<IMappable>();
            foreach (var mappable in kvp.Value)
            {
                valueListCopy.Add(mappable);
            }

            deepCopy[keyCopy] = valueListCopy;
        }

        return deepCopy;
    }

}
