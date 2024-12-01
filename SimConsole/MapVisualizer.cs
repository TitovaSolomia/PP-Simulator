using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;
using Simulator.Animals;

namespace SimConsole;

public class MapVisualizer
{
    public Map Map { get; }
    public MapVisualizer (Map map)
    {
        Map = map;
    }

    private char GetPointChar(int x, int y) 
    {
        List<IMappable> mappables = Map.At(x, y);

        if (mappables == null || mappables.Count() == 0) return ' ';
        else if (mappables.Count() >= 2) return 'X';
        else return mappables[0].Symbol;
    }

    public void Draw()
    {
        for (int row = Map.SizeY - 1; row >= 0; row--)
        {
            for (int col = 0; col < Map.SizeX; col++)
            {
                if (col == 0) Console.Write(Box.TopLeft);

                Console.Write(Box.Horizontal);

                if (col == Map.SizeX - 1) Console.Write(Box.TopRight);
                else Console.Write(Box.TopMid);
            }
            Console.WriteLine();

            for (int col = 0; col < Map.SizeX; col++)
            {
                Console.Write(Box.Vertical);
                Console.Write(GetPointChar(col, row));
            }
            Console.WriteLine(Box.Vertical);

        }

        for (int col = 0; col < Map.SizeX; col++)
        {
            if (col == 0) Console.Write(Box.BottomLeft);

            Console.Write(Box.Horizontal);

            if (col == Map.SizeX - 1) Console.Write(Box.BottomRight);
            else Console.Write(Box.BottomMid);
        }

        Console.WriteLine();

    }



}
