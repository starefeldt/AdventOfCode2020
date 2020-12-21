using System;

namespace AdventOfCode.Domain.Day_9
{
    public class SimpleReturn : IFaultedNumberAlgorithm
    {
        public long Calculate(long[] _, long value) => value;
    }
}
