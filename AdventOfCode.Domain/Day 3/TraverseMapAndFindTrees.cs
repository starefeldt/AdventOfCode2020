using AdventOfCode.Utility;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class TraverseMapAndFindTrees : IPuzzle
    {
        private readonly List<SlopeData> _completeSlopeData;
        private List<string> _input;

        public TraverseMapAndFindTrees(string fileName, List<SlopeData> completeSlopeData)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .ToList();
            _completeSlopeData = completeSlopeData;
        }

        public long Solve()
        {
            var completeTreeCount = new List<long>();
            foreach (var slopeData in _completeSlopeData)
            {
                int currentIndex = 0;
                int foundTrees = 0;
                int rowIndex = slopeData.Down;

                while (rowIndex < _input.Count)
                {
                    var row = _input[rowIndex];
                    currentIndex = (currentIndex + slopeData.Right) % row.Length; //traverse circular array
                    var coordinate = row[currentIndex];
                    if (coordinate == '#')
                    {
                        foundTrees++;
                    }
                    rowIndex += slopeData.Down;
                }
                completeTreeCount.Add(foundTrees);
            }
            return completeTreeCount.Aggregate((a, b) => a * b);
        }
    }
}
