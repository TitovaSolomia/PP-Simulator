using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
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

    public string Go(Direction direction) => direction.ToString().ToLower();
        

    public string[] Go(Direction[] directions)
    {
            var result = new string[directions.Length];
            for (int i = 0; i < directions.Length; i++)
            {
                result[i] = Go(directions[i]);
            }

            return result;     
    }

    public string[] Go(string directionSeq) =>
        Go(DirectionParser.Parse(directionSeq));
         
}
