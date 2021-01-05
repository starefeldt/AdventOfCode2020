using System;

namespace AdventOfCode.Domain.Day_12
{
    public class WaypointShip : IShip
    {
        public Direction Heading => Direction.Waypoint;

        public Point Position { get; }

        public Point WayPoint { get; }

        public WaypointShip(Point wayPoint, Point position)
        {
            WayPoint = wayPoint;
            Position = position;
        }

        public void Steer(Direction direction, int unit)
        {
            switch (direction)
            {
                case Direction.Waypoint:
                    Position.NorthSouth += WayPoint.NorthSouth * unit;
                    Position.EastWest += WayPoint.EastWest * unit;
                    break;
                case Direction.North:
                    WayPoint.NorthSouth += unit;
                    break;
                case Direction.South:
                    WayPoint.NorthSouth -= unit;
                    break;
                case Direction.East:
                    WayPoint.EastWest += unit;
                    break;
                case Direction.West:
                    WayPoint.EastWest -= unit;
                    break;
            }
        }

        public void Turn(Turn turn, int degree)
        {
            var ns = (Direction)WayPoint.NorthSouth > 0
                ? Direction.North
                : Direction.South;

            var ew = (Direction)WayPoint.EastWest > 0
                ? Direction.East
                : Direction.West;

            switch (turn)
            {
                case
                Day_12.Turn.Left:
                    {
                        var newFromNs = GetNewDirection(WayPoint.NorthSouth, (int)ns - degree);
                        var newFromEw = GetNewDirection(WayPoint.EastWest, (int)ew - degree);
                        SetWayPoint(newFromNs);
                        SetWayPoint(newFromEw);
                        break;
                    }
                case Day_12.Turn.Right:
                    {
                        var newFromNs = GetNewDirection(WayPoint.NorthSouth, (int)ns + degree);
                        var newFromEw = GetNewDirection(WayPoint.EastWest, (int)ew + degree);
                        SetWayPoint(newFromNs);
                        SetWayPoint(newFromEw);
                        break;
                    }
            }
        }

        private (Direction Direction, int Unit) GetNewDirection(int oldValue, int value)
        {
            if (value > 0)
                while (value >= 360)
                    value -= 360;
            else
                while (value < 0)
                    value += 360;

            var newDirection = (Direction)value;
            var signedValue = Math.Abs(oldValue);
            if (newDirection == Direction.South || newDirection == Direction.West)
            {
                return (newDirection, signedValue * -1);    //return negetive value to indicate south and west
            }
            return (newDirection, signedValue);
        }

        private void SetWayPoint((Direction Direction, int Unit) data)
        {
            switch (data.Direction)
            {
                case Direction.North:
                case Direction.South:
                    WayPoint.NorthSouth = data.Unit;
                    break;
                case Direction.East:
                case Direction.West:
                    WayPoint.EastWest = data.Unit;
                    break;
            }
        }
    }
}
