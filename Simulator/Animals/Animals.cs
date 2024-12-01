using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator.Animals;

public abstract class Animals : IMappable
{
    private string description = "Unknown";
    public Map? Map { get; protected set; }
    public Point Position { get; protected set; }

    public virtual char Symbol
    {
        get { return 'A'; }
    }

    public string Description
    {
        get => description;
        init => description = Validator.Shortener(value);
    }
    public uint Size { get; set; } = 3;

    public override string ToString()
    {
        var className = GetType().Name;
        return $"{className.ToUpper()}: {Info}";
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        if (Map == null)
        {
            Map = map;
            Position = point;
            map.Add(this, point);
        }
    }

    public abstract void Go(Direction currentMove);


    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
