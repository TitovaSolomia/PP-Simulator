using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Mappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public List<Direction> Moves { get; }

    public int IndexOfAction = 0;
    public int IndexOfMove = 0;

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable 
    { 
       get => Mappables[IndexOfAction];
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public Direction CurrentMove 
    {
        get => Moves[IndexOfMove];
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    { 
        if (mappables == null || !mappables.Any())
        {
            throw new ArgumentException("Lista jest pusta");
        }

        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("Liczba stworów jest różna od liczby pozycji startowych");
        }

        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = DirectionParser.Parse(moves);

        InitCreaturesPositions(mappables, positions, map);
    }

    private void InitCreaturesPositions(List<IMappable> mappables, List<Point> points, Map map)
    {
        for (int i = 0; i < mappables.Count; i++) 
        {
            mappables[i].InitMapAndPosition(map, points[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        CurrentMappable.Go(CurrentMove);
        IndexOfAction = (IndexOfAction + 1) % Mappables.Count;
        IndexOfMove++;

        if (IndexOfMove >= Moves.Count()) 
        { 
            Finished = true;
        }

    }
}
