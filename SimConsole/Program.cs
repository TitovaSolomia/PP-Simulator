using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap mapSquare = new(5);
        SmallTorusMap mapTorus = new(6, 5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3,1)];
        string moves = "dluld";

        Simulation simulation = new(mapTorus, creatures, points, moves);
        MapVisualizer mapVisualizer = new(mapTorus);

        Play(mapVisualizer, simulation);
    }

    public static void Play(MapVisualizer mapVisualizer, Simulation simulation)
    {
        Console.WriteLine("Stan początkowy mapy:");
        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
            ShowTurnInfo(simulation);
            simulation.Turn();
            mapVisualizer.Draw();
        }

        Console.WriteLine("Koniec gry");
    }

    public static void ShowTurnInfo(Simulation simulation)
    {
        Creature creature = simulation.CurrentCreature;
        Console.Write(creature.GetType().Name + ": " + creature.Name + " [" + creature.Level + "] [" + GetPower(creature) + "] " + creature.Position + " ") ;
        Console.WriteLine("go " + simulation.CurrentMove.ToString());

    }

    public static string GetPower(Creature creature)
    {
        switch (creature)
        {
            case Orc o:
                return o.Rage.ToString();
            case Elf e:
                return e.Agility.ToString();
            default:
                return " ";
        }
    }
}
