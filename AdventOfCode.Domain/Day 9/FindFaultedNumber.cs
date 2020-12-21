using AdventOfCode.Domain.Day_9;
using AdventOfCode.Utility;
using System;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindFaultedNumber : IPuzzle
    {
        private long[] _input;
        private readonly IFaultedNumberAlgorithm _algorithm;
        private readonly int _preambleLength;

        public FindFaultedNumber(string fileName, IFaultedNumberAlgorithm algorithm, int preambleLength)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .Select(n => long.Parse(n))
                .ToArray();
            _algorithm = algorithm;
            _preambleLength = preambleLength;
        }

        public long Solve()
        {
            var a = 0;
            var b = _preambleLength;
            var preamble = _input[a..b];

            for (int i = b; i < _input.Length; i++)
            {
                var value = _input[i];
                if (!CanValueBeSummedInPreamble(preamble, value))
                {
                    return _algorithm.Calculate(_input, value);
                }
                preamble = _input[(++a)..(++b)];
            }
            throw new InvalidOperationException("Could not solve");
        }

        private bool CanValueBeSummedInPreamble(long[] preamble, long value)
        {
            for (int i = 0; i < preamble.Length; i++)
            {
                for (int j = i + 1; j < preamble.Length; j++)
                {
                    if (preamble[i] + preamble[j] == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
