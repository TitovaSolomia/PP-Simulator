using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;

    private int huntCounter = 0;
    public Orc() { }
    public Orc(string name, int level, int rage = 1) : base(name, level) 
    {
        Rage = rage;
    }
    public int Rage
    {
        get => rage;

        init => rage = Validator.Limiter(value, 0, 10);
    }
    public void Hunt() {

        Console.WriteLine($"{Name} is hunting.");

        huntCounter++;

        if (huntCounter == 3)
        {
            if (rage < 10)
            {
                rage++;
                Console.WriteLine($"{Name}'s agility increased to {Rage}!");
            }
            else
            {
                Console.WriteLine($"{Name} has reached maximum agility.");
            }

            huntCounter = 0;
        }
    }

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info
    {
        get { return $"{Name} [{Level}][{Rage}]"; } 
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
    );



}
