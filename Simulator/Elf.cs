﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    public override char Symbol
    {
        get { return 'E'; }
    }

    public Elf() { }

    public Elf(string name, int level = 0, int agility=1) : base(name, level) 
    { 
        Agility = agility;
    }
    private int agility  = 1;

    private int singCounter = 0;

    public int Agility
    {
        get => agility;

        init => agility = Validator.Limiter(value, 0, 10);
    }

    public void Sing()
    {
        

        singCounter++;

        if (singCounter == 3)
        {
            if (agility < 10)
            {
                agility++;
            }
            singCounter = 0;
        }
    }

    public override int Power => 8 * Level + 2 * Agility ;

    public override string Info
    {
        get { return $"{Name} [{Level}][{Agility}]"; }
    }
     public override string Greeting() =>  $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

}
