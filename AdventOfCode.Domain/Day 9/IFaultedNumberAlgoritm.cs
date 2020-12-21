namespace AdventOfCode.Domain.Day_9
{
    public interface IFaultedNumberAlgorithm
    {
        long Calculate(long[] input, long faultedValue);
    }
}
