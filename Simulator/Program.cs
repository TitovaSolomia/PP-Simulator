namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Creature a = new Creature();

        a.SayHi();

        a.Name = "P.Diddy";
        a.Level = 4;

        Console.WriteLine(a.Info);


        Animals animal = new Animals { Description = "Dogs" };

        Console.WriteLine(animal.Info);  

        animal.Size = 5;
        Console.WriteLine(animal.Info);  
    }

    
}
