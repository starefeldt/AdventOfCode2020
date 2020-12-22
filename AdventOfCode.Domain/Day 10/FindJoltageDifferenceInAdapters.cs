using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindJoltageDifferenceInAdapters : IPuzzle
    {
        private List<int> _input;

        public FindJoltageDifferenceInAdapters(string fileName)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .Select(n => int.Parse(n))
                .ToList();
        }

        public long Solve()
        {
            _input.Add(_input.Max() + 3);   //built-in adapter is 3 higher than highest
            var joltages = _input.OrderBy(n => n);

            var occurences = new Dictionary<int, int>();
            var currentJoltage = 0;
            foreach (var joltage in joltages)
            {
                var difference = joltage - currentJoltage;
                if (difference == 1 || difference == 3)
                {
                    if (!occurences.TryGetValue(difference, out int occurence))
                    {
                        occurences.Add(difference, occurence);
                    }
                    occurences[difference] = ++occurence;
                }
                currentJoltage = joltage;
            }

            return occurences[1] * occurences[3];
        }
    }
}
