using AdventOfCode.Utility;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Domain
{
    public class PuzzleTemplate : IPuzzle
    {
        private IEnumerable<string> _input;

        public PuzzleTemplate(string fileName)
        {
            _input = InputHelper
                .ReadAllLines(fileName);
        }

        public int Solve()
        {
            throw new InvalidOperationException("Could not solve puzzle");
        }
    }
}
