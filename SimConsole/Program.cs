using Simulator.Maps;
using Simulator;
using System.Text;
using Simulator.Animals;
using Simulator.History;

namespace SimConsole;

internal class Program
{
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        BigBounceMap map = new BigBounceMap(8, 6);
        MapVisualizer visualizer = new MapVisualizer(map);

        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Ostrich(), new Rabbit(), new Eagle()];
        List<Point> points = [new(2, 2), new(3, 1), new(1, 3), new(1, 3), new(5, 1)];

        string moves = "lllrdrdrrrdrd";

        Simulation simulation = new(map, mappables, points, moves);

        SimulationHistory simulationHistory = new(simulation);
        LogVisualizer logVisualizer = new LogVisualizer(simulationHistory);

        Play(visualizer, simulation, simulationHistory);

        logVisualizer.ShowTurn(2);
        logVisualizer.ShowTurn(5);
        logVisualizer.ShowTurn(10);
    }

    public static void Play(MapVisualizer mapVisualizer, Simulation simulation, SimulationHistory simulationHistory)
    {
        Console.WriteLine("Stan początkowy mapy:");
        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();

            IMappable current = simulation.CurrentMappable;
            Direction currentDirection = simulation.CurrentMove;
            string TurnInfo = ShowTurnInfo(current, currentDirection);
            simulation.Turn();

            simulationHistory.SaveStep(TurnInfo, simulation.Map.GetMapState());
            mapVisualizer.Draw();
        }

        Console.WriteLine("Koniec gry");
    }

    private static string ShowTurnInfo(IMappable currentMappable, Direction currentDirection)
    {
        string TurnInfo = currentMappable.GetType().Name + ": " + currentMappable.Position + " go " + currentDirection.ToString();
        Console.WriteLine(TurnInfo);
        return TurnInfo;
    }

    private static string GetPower(Creature mappable)
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
