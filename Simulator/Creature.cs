using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

internal class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name
    {
        get => name;
        init
        {
            var checked_name = value.Trim();

            if (checked_name.Length > 25)
            {
                checked_name = checked_name.Substring(0, 25).TrimEnd();
            }

            if (checked_name.Length < 3)
            {
                checked_name = checked_name.PadRight(3, '#');
            }

            if (char.IsLower(checked_name[0]))
            {
                checked_name = char.ToUpper(checked_name[0]) + checked_name.Substring(1);
            }

            name = checked_name;
        }
    }

    public int Level
    {
        get => level;
        init => level = value < 1 ? 1 : value > 10 ? 10 : value;
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public string Info => $"{Name} [{Level}]";

    public void SayHi()
    {
        Console.WriteLine($"My name is {Name}, my level is {Level}.");
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public void Go(Direction direction)
    {
        string str = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {str}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string input)
    {
        Direction[] directions = DirectionParser.Parse(input);
        Go(directions); 
    }
}
