using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace SimConsole;

public class SimulationHistory
{
    private Simulation simulation;
    private MapVisualizer mapVisualizer;
    private List<HistoryItem> history = new List<HistoryItem>();
    public SimulationHistory (Simulation simulation)
    {
        this.simulation = simulation;
        this.mapVisualizer = new(simulation.Map);

    }

    public void Play()
    {
        Console.WriteLine("Stan początkowy mapy:");
        this.mapVisualizer.Draw();

        while (!this.simulation.Finished)
        {
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();

            IMappable current = this.simulation.CurrentMappable;
            Direction currentDirection = this.simulation.CurrentMove;
            ShowTurnInfo(current, currentDirection);
            this.simulation.Turn();

            this.SaveStep(current, currentDirection);
            this.mapVisualizer.Draw();
        }

        Console.WriteLine("Koniec gry");
    }

    public void RepeatTurn(int turnNumber) 
    {
        HistoryItem historyItem = history[turnNumber];
        Map turnMap = this.CreateMap();
        turnMap.SetMapState(historyItem.mapState);
        MapVisualizer turnMapVisualizer = new MapVisualizer(turnMap);
        ShowTurnInfo(historyItem.actualCharacter, historyItem.actualDirection);
        turnMapVisualizer.Draw();

    }

    private void ShowTurnInfo(IMappable currentMappable, Direction currentDirection)
    {
        Console.Write(currentMappable.GetType().Name + ": " + currentMappable.Position + " ");
        Console.WriteLine("go " + currentDirection.ToString());

    }

    private string GetPower(Creature mappable)
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

    private void SaveStep(IMappable currentMappable, Direction currentDirection)
    {
        HistoryItem historyItem = new(currentMappable, currentDirection, this.simulation.Map.GetMapState());
        this.history.Add(historyItem);
    }

    private Map CreateMap() 
    {
        switch (this.simulation.Map)
        {
            case SmallSquareMap smallSquareMap:
                return new SmallSquareMap (this.simulation.Map.SizeX);
            case BigBounceMap bigBounceMap:
                return new BigBounceMap (this.simulation.Map.SizeX, this.simulation.Map.SizeY);
            case SmallTorusMap smallTorusMap:
                return new SmallTorusMap(this.simulation.Map.SizeX, this.simulation.Map.SizeY);
            default:
                return null;
        }
    }
}
