using AdventOfCode.Domain.Day_8;
using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindFirstRepeatedJump : IPuzzle
    {
        private List<IEnumerable<string>> _input;

        public FindFirstRepeatedJump(string fileName)
        {
            _input = InputHelper
                .ReadAllLinesAndSplitOn(fileName, " ")
                .ToList();
        }

        public long Solve()
        {
            int accValue = 0;
            int i = 0;
            var indexRepeatChecker = new List<int>();
            while (!indexRepeatChecker.Contains(i))
            {
                indexRepeatChecker.Add(i);
                var operation = Enum.Parse<Operation>(_input[i].First());
                var instruction = int.Parse(_input[i].Last());
                switch (operation)
                {
                    case Operation.nop:
                        i++;
                        break;
                    case Operation.acc:
                        accValue += instruction;
                        i++;
                        break;
                    case Operation.jmp:
                        i += instruction;
                        break;
                }
            }
            return accValue;
        }
    }
}
