using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    
    public abstract class BigMap : Map
    {
        Dictionary<Point, List<IMappable>> _fields;

        public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
            }

            if (sizeY > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
            }

            _fields = new Dictionary<Point, List<IMappable>>();
        }

        public override void Add(IMappable mappable, Point point)
        {
            if (!Exist(point)) return;


            if (!_fields.ContainsKey(point))
            {
                List<IMappable> creaturesOfPoint = new List<IMappable> { mappable };
                _fields[point] = creaturesOfPoint;
            }
            else
            {
                List<IMappable> creaturesOfPoint = _fields[point];
                creaturesOfPoint.Add(mappable);
            }

        }

        public override void Remove(IMappable mappable, Point point)
        {
            if (!Exist(point)) return;

            if (!_fields.ContainsKey(point)) return;

            List<IMappable> creatures = _fields[point];

            if (creatures.Contains(mappable))
            {
                creatures.Remove(mappable);
            }
            else
            {
                Console.WriteLine("Nie ma objektu w tym punkcie");
            }
        }

        public override void Move(IMappable mappable, Point pointFrom, Point pointTo)
        {
            if (!Exist(pointTo)) return;

            Remove(mappable, pointFrom);
            Add(mappable, pointTo);
        }

        public override List<IMappable> At(Point point)
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

        public override List<IMappable> At(int x, int y)
        {
            Point point = new Point(x, y);
            return At(point);
        }
    }
}
