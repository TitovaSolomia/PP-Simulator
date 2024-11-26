using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class MapVisualizer
{
    public Map Map { get; }
    public MapVisualizer (Map map)
    {
        Map = map;
    }

    private char GetCreatureLetter(Creature creature)
    {
        switch (creature)
        {
            case Orc o:
                return 'O';
            case Elf e:
                return 'E';
            default:
                return ' ';
        }
    }

    private char GetPointChar(int x, int y) 
    {
        List<Creature> creatures = Map.At(x, y);

        if (creatures == null || creatures.Count() == 0) return ' ';
        else if (creatures.Count() >= 2) return 'X';
        else return GetCreatureLetter(creatures[0]);
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
