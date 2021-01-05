namespace AdventOfCode.Domain.Day_12
{
    public interface IShip
    {
        Direction Heading { get; }
        Point Position { get; }
        void Steer(Direction direction, int unit);
        void Turn(Turn turn, int unit);
    }
}