using Simulator.Maps;
using Simulator;
using System.Text;
using Simulator.Animals;

namespace SimConsole;

internal class Program
{
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new SmallTorusMap(8, 6);

        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Ostrich(), new Rabbit(), new Eagle()];
        List<Point> points = [new(2, 2), new(3, 1), new(1, 3), new(1, 3), new(5, 1)];

        string moves = "ruuldrrluddlruu";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

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
        IMappable mappable = simulation.CurrentMappable;
        Console.Write(mappable.GetType().Name + ": " + mappable.Position + " ") ;
        Console.WriteLine("go " + simulation.CurrentMove.ToString());

    }

    public static string GetPower(Creature mappable)
    {
        switch (mappable)
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
