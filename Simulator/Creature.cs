using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public abstract char Symbol { get; }


    public void InitMapAndPosition(Map map, Point position) { 
        if (this.Map == null)
        {
            this.Map = map;
            this.Position = position;
            map.Add(this, position);
        }
    
    }

    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value);
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 0, 10);
    }

    public Creature() { }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public override string ToString()
    {
        var className = this.GetType().Name;
        return $"{className.ToUpper()}: {this.Info}";
    }
    public abstract string Info { get; }

    public abstract string Greeting();
    public abstract int Power { get; }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }
    public void Go(Direction direction)
    {
        Point newPoint = this.Map.Next(this.Position, direction);
        this.Map.Move(this, this.Position, newPoint);
        this.Position = newPoint;
    }
}
