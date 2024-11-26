using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    Dictionary<Point, List<Creature>> _fields; 


    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }

        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }

        _fields = new Dictionary<Point, List<Creature>>();
    }

    public override void Add(Creature creature, Point point)
    {
        if (!Exist(point)) return;
      

        if (!_fields.ContainsKey(point))
        {
            List<Creature> creaturesOfPoint = new List<Creature> { creature };
            _fields[point] = creaturesOfPoint;
        }
        else
        {
            List<Creature> creaturesOfPoint = _fields[point];
            creaturesOfPoint.Add(creature);
        }

    }

    public override void Remove(Creature creature, Point point)
    {
        if (!Exist(point)) return;

        if (!_fields.ContainsKey(point)) return;

        List<Creature> creatures = _fields[point];

        if (creatures.Contains(creature))
        {
            creatures.Remove(creature);
        }
        else
        {
            Console.WriteLine("Nie ma stworu w tym punkcie");
        }
    }

    public override void Move(Creature creature, Point pointFrom, Point pointTo)
    {
        if (!Exist(pointTo)) return; 

        Remove(creature, pointFrom);
        Add(creature, pointTo);
    }

    public override List<Creature> At(Point point)
    {

        if (Exist(point) && _fields.ContainsKey(point))
        {
            return _fields[point];
        }
        else
        {
            return null;
        }
    }

    public override List<Creature> At(int x, int y)
    {
        Point point = new Point(x, y);
        return At(point);
    }
}
