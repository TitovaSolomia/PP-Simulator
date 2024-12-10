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

        BigBounceMap map = new BigBounceMap(8, 6);

        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Ostrich(), new Rabbit(), new Eagle()];
        List<Point> points = [new(2, 2), new(3, 1), new(1, 3), new(1, 3), new(5, 1)];

        string moves = "lllrdrdrrrdrd";

        Simulation simulation = new(map, mappables, points, moves);

        SimulationHistory simulationHistory = new(simulation);

        simulationHistory.Play();

        simulationHistory.RepeatTurn(2);
        simulationHistory.RepeatTurn(5);
        simulationHistory.RepeatTurn(10);
    }

}
