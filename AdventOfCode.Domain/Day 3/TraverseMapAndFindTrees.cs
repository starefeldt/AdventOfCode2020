using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class TraverseMapAndFindTrees : IPuzzle
    {
        private List<string> _input;

        public TraverseMapAndFindTrees(string fileName)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .ToList();
        }

        public int Solve()
        {
            int currentIndex = 0;
            int foundTrees = 0;
            //Rules: move forward 3 places and 1 step down to next row until array is finished
            for (int i = 1; i < _input.Count; i++)
            {
                var row = _input[i];
                currentIndex = (currentIndex + 3) % row.Length; //traverse circular array
                var coordinate = row[currentIndex];
                if(coordinate == '#')
                {
                    foundTrees++;
                }
            }
            return foundTrees;
        }
    }
}
