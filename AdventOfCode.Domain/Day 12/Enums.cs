namespace AdventOfCode.Domain.Day_12
{
    public enum Code { N, S, E, W, L, R, F }
    public enum Direction { North = 0, East = 90, South = 180, West = 270, Waypoint = int.MinValue}
    public enum Turn { Left, Right }
}
