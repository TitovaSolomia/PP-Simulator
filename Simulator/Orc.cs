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
    public Orc(string name, int level = 0, int rage = 1) : base(name, level) 
    {
        Rage = rage;
    }
    public int Rage
    {
        get => rage;

        init => rage = Validator.Limiter(value, 0, 10);
    }
    public void Hunt() {

        huntCounter++;

        if (huntCounter == 3)
        {
            if (rage < 10)
            {
                rage++;
            }

            huntCounter = 0;
        }
    }

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info
    {
        get { return $"{Name} [{Level}][{Rage}]"; } 
    }

    public override string Greeting() => 
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

}
