using AdventOfCode.Utility;
using System;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class SumRangeOfNumbers : IPuzzle
    {
        private long[] _input;

        public SumRangeOfNumbers(string fileName)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .Select(n => long.Parse(n))
                .ToArray();
        }

        public long Solve()
        {
            var a = 0;
            var b = 25;
            var preamble = _input[a..b];

            for (int i = b; i < _input.Length; i++)
            {
                var value = _input[i];
                if (!CanValueBeSummedInPreamble(preamble, value))
                {
                    return value;
                }
                preamble = _input[(a += 1)..(b += 1)];
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
