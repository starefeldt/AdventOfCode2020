using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain.Day_9
{
    public class FindSumOfFaultedInPreamble : IFaultedNumberAlgorithm
    {
        private readonly int _preambleLength;

        public FindSumOfFaultedInPreamble(int preambleLength)
        {
            _preambleLength = preambleLength;
        }
        public long Calculate(long[] input, long faultedValue)
        {
            var a = 0;
            var b = _preambleLength;
            var preamble = input[a..b];

            for (int i = 0; i < input.Length; i++)
            {
                var adjacentNums = new List<long>();
                var nextPreambleValue = 0;
                while (nextPreambleValue < _preambleLength && adjacentNums.Sum() < faultedValue)
                {
                    adjacentNums.Add(preamble[nextPreambleValue]);
                    nextPreambleValue++;
                }
                if (adjacentNums.Sum() == faultedValue)
                {
                    return adjacentNums.Min() + adjacentNums.Max();
                }
                preamble = input[(++a)..(++b)];
            }
            throw new InvalidOperationException("Could not solve");
        }
    }
}
