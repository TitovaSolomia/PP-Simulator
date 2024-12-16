using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Rectangle _map;
    public int SizeX { get; }
    public int SizeY { get; }

    Dictionary<Point, List<IMappable>> _fields;

    protected Map(int sizeX, int sizeY)
    {

        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }


        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        _fields = new Dictionary<Point, List<IMappable>>();
    }
    public void Add(IMappable mappable, Point point)
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

    public void Remove(IMappable mappable, Point point)
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

    public void Move(IMappable mappable, Point pointFrom, Point pointTo)
    {
        if (!Exist(pointTo)) return;

        Remove(mappable, pointFrom);
        Add(mappable, pointTo);
    }

    public List<IMappable> At(Point point)
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

    public List<IMappable> At(int x, int y)
    {
        Point point = new Point(x, y);
        return At(point);
    }

    public Dictionary<Point, char> GetMapState() { 
        
        Dictionary<Point, char> mapState = new Dictionary<Point, char>();

        for (int x = 0; x < this.SizeX; x++)
        { 
            for (int y = 0; y < this.SizeY; y++)
            {
                mapState.Add(new Point(x, y), this.GetPointChar(x, y));
            }
        }

        return mapState;
    }

    public void SetMapState(Dictionary<Point, List<IMappable>> mapState)
    {
        this._fields = mapState;
    }

    public char GetPointChar(int x, int y)
    {
        List<IMappable> mappables = this.At(x, y);

        if (mappables == null || mappables.Count() == 0) return ' ';
        else if (mappables.Count() >= 2) return 'X';
        else return mappables[0].Symbol;
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _map.Contains(p); 

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

}