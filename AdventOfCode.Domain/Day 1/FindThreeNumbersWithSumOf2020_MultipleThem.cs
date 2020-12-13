using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindThreeNumbersWithSumOf2020_MultipleThem : IPuzzle
    {
        private List<int> _numbers;
        private const int Target = 2020;

        public FindThreeNumbersWithSumOf2020_MultipleThem(string fileName)
        {
            _numbers = InputHelper
                .ReadAllLines(fileName)
                .Select(n => int.Parse(n))
                .ToList();
        }

        public long Solve()
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                var num1 = _numbers[i];
                for (int j = i + 1; j < _numbers.Count; j++)
                {
                    var num2 = _numbers[j];
                    for (int k = j + 1; k < _numbers.Count; k++)
                    {
                        var num3 = _numbers[k];
                        if (num1 + num2 + num3 == Target)
                        {
                            return num1 * num2 * num3;
                        }
                    }
                }
            }
            throw new InvalidOperationException("No match");
        }
    }
}
