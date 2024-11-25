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
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public List<Direction> Moves { get; }

    public int IndexOfAction = 0;
    public int IndexOfMove = 0;

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature 
    { 
       get => Creatures[IndexOfAction];
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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    { 
        if (creatures == null || !creatures.Any())
        {
            throw new ArgumentException("Lista jest pusta");
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Liczba stworów jest różna od liczby pozycji startowych");
        }

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = DirectionParser.Parse(moves);

        InitCreaturesPositions(creatures, positions, map);
    }

    private void InitCreaturesPositions(List<Creature> creatures, List<Point> points, Map map)
    {
        for (int i = 0; i < creatures.Count; i++) 
        {
            creatures[i].InitMapAndPosition(map, points[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        CurrentCreature.Go(CurrentMove);
        IndexOfAction = (IndexOfAction + 1) % Creatures.Count;
        IndexOfMove++;

        if (IndexOfMove >= Positions.Count()) 
        { 
            Finished = true;
        }

    }
}
