using AdventOfCode.Utility;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindAllWorkingCombinationsInAdapters : IPuzzle
    {
        private List<int> _input;

        public FindAllWorkingCombinationsInAdapters(string fileName)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .Select(n => int.Parse(n))
                .ToList();
        }

        public long Solve()
        {
            _input.Insert(0, 0);
            var joltages = _input.OrderBy(i => i).ToList();
            var combinations = new long[joltages.Count];
            combinations[0] = 1;    //start with one combination

            for (var i = 1; i < joltages.Count; i++)
            {
                var current = joltages[i];
                for (var j = 0; j < i; j++)
                {
                    var behindCurrentWithMax3 = joltages[j];
                    if (current - behindCurrentWithMax3 <= 3)
                    {
                        //Sum up combinations that we have found so far - drag them along that is!
                        combinations[i] += combinations[j];
                    }
                }
            }
            return combinations.Last();
        }
    }
}
