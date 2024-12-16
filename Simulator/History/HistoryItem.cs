using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class HistoryItem
{
    public Dictionary<Point, char> mapState { get; private set; }
    public string TurnInfo { get; private set; }

    public HistoryItem (Dictionary<Point, char> mapState, string TurnInfo) 
    { 
        this.mapState = mapState;
        this.TurnInfo = TurnInfo;
        
    }
}
