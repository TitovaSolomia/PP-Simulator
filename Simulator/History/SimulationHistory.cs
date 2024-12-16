using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace Simulator.History;

public class SimulationHistory
{
    public Simulation simulation;
    public List<HistoryItem> history = new List<HistoryItem>();
    public SimulationHistory(Simulation simulation)
    {
        this.simulation = simulation;

    }
    public void SaveStep(string TurnInfo, Dictionary<Point, char> mapState)
    {
        HistoryItem historyItem = new(mapState, TurnInfo);
        this.history.Add(historyItem);
    }

    public HistoryItem GetTurnItem(int TurnNumber) 
    { 
        return this.history[TurnNumber];
    }
}
