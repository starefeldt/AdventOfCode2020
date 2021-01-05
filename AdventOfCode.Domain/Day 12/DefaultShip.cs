using System;

namespace AdventOfCode.Domain.Day_12
{
    public class DefaultShip : IShip
    {
        public Direction Heading { get; private set; }
        public Point Position { get; private set; }

        public DefaultShip(Direction heading, Point position)
        {
            Heading = heading;
            Position = position;
        }

        public void Steer(Direction direction, int unit)
        {
            switch (direction)
            {
                case Direction.North:
                    Position.NorthSouth += unit;
                    break;
                case Direction.South:
                    Position.NorthSouth -= unit;
                    break;
                case Direction.East:
                    Position.EastWest += unit;
                    break;
                case Direction.West:
                    Position.EastWest-= unit;
                    break;
            }
        }

        public void Turn(Turn turn, int unit)
        {
            var degree = (int)Heading;
            switch (turn)
            {
                case Day_12.Turn.Left:
                    {
                        degree -= unit;
                        while (degree < 0)
                            degree += 360;
                        break;
                    }
                case Day_12.Turn.Right:
                    {
                        degree += unit;
                        while (degree >= 360)
                            degree -= 360;
                        break;
                    }
            }
            Heading = (Direction)degree;
        }
    }
}
