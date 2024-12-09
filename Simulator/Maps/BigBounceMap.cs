using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {

        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            
        }

        public override Point Next(Point p, Direction d)
        {
            Point newPoint = p.Next(d);

            if (Exist(newPoint))
                return newPoint;

            Direction oppositeDirection = OppositeDirection(d);
            newPoint = p.Next(oppositeDirection);

            if (Exist(newPoint))
                return newPoint;

            return p;

        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point newPoint = p.NextDiagonal(d);

            if (Exist(newPoint))
                return newPoint;
            
            Direction oppositeDirection = OppositeDirection(d);
            newPoint = p.NextDiagonal(oppositeDirection);

            if (Exist(newPoint))
                return newPoint;

            return p;
        }

        private Direction OppositeDirection(Direction d)
        {
            switch (d)
            {
                case Direction.Left:
                    return Direction.Right;

                case Direction.Right:
                    return Direction.Left;

                case Direction.Up:
                    return Direction.Down;

                case Direction.Down:
                    return Direction.Up;
            } 
            return d;
        }
    }
}
