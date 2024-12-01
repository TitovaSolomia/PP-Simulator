using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public abstract class Animals : IMappable
{
    private string description = "Unknown";
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public string Description
    {
        get => description;
        init => description=Validator.Shortener(value);
    }
    public uint Size { get; set; } = 3;

    public override string ToString()
    {
        var className = this.GetType().Name;
        return $"{className.ToUpper()}: {this.Info}";
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        if (this.Map == null)
        {
            this.Map = map;
            this.Position = point;
            map.Add(this, point);
        }
    }

    public void Go(Direction currentMove)
    {
        throw new NotImplementedException();
    }

    public virtual string Info 
    { 
        get { return $"{Description} <{Size}>"; }
    }
}
