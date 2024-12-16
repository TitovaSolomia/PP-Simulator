using Simulator;
using Simulator.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

public class LogVisualizer
{
    public SimulationHistory History;
    public int sizeX;
    public int sizeY;

    public LogVisualizer(SimulationHistory History) 
    { 
        this.History = History;
        this.sizeX = History.simulation.Map.SizeX;
        this.sizeY = History.simulation.Map.SizeY;
    }

    public void ShowTurn (int turnNumber)
    {
        HistoryItem historyItem = this.History.GetTurnItem(turnNumber);
        this.Draw(historyItem);
    }
    private void Draw(HistoryItem historyItem)
    {
        Console.WriteLine(historyItem.TurnInfo);

        for (int row = this.sizeY - 1; row >= 0; row--)
        {
            for (int col = 0; col < this.sizeX; col++)
            {
                if (col == 0) Console.Write(Box.TopLeft);

                Console.Write(Box.Horizontal);

                if (col == this.sizeX - 1) Console.Write(Box.TopRight);
                else Console.Write(Box.TopMid);
            }
            Console.WriteLine();

            for (int col = 0; col < this.sizeX; col++)
            {
                Console.Write(Box.Vertical);
                Console.Write(historyItem.mapState[new Point(col, row)]);
            }
            Console.WriteLine(Box.Vertical);

        }

        for (int col = 0; col < this.sizeX; col++)
        {
            if (col == 0) Console.Write(Box.BottomLeft);

            Console.Write(Box.Horizontal);

            if (col == this.sizeX - 1) Console.Write(Box.BottomRight);
            else Console.Write(Box.BottomMid);
        }

        Console.WriteLine();

    }
}
