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
        get { return name; }
        set { name = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public Creature() { }

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void SayHi()
    {
        Console.WriteLine($"My name is {Name}, my level is {Level}.");
    }

}
