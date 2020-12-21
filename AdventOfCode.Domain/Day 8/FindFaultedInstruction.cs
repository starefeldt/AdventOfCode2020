using AdventOfCode.Domain.Day_8;
using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class FindFaultedInstruction : IPuzzle
    {
        private List<IEnumerable<string>> _input;

        public FindFaultedInstruction(string fileName)
        {
            _input = InputHelper
                .ReadAllLinesAndSplitOn(fileName, " ")
                .ToList();
        }

        public long Solve()
        {
            int accValue = 0;
            var lastCheckedIndex = _input.Count;
            var instructions = new List<IEnumerable<string>>(_input);

            while (!IsCompleteRun(ref accValue, instructions))
            {
                lastCheckedIndex = ChangeOneOperationInInstructionsFromBack(ref instructions, lastCheckedIndex - 1);
            }
            return accValue;
        }

        private bool IsCompleteRun(ref int accValue, List<IEnumerable<string>> instructions)
        {
            var indexRepeatChecker = new List<int>();
            int i = 0;
            while (i < instructions.Count)
            {
                if (indexRepeatChecker.Contains(i))
                {
                    accValue = 0;
                    return false;
                }
                indexRepeatChecker.Add(i);
                var operation = Enum.Parse<Operation>(instructions[i].First());
                var instruction = int.Parse(instructions[i].Last());
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
            return true;
        }

        private int ChangeOneOperationInInstructionsFromBack(ref List<IEnumerable<string>> instructions, int lastCheckedIndex)
        {
            instructions = new List<IEnumerable<string>>(_input);
            for (int i = lastCheckedIndex; i >= 0; i--)
            {
                var op = Enum.Parse<Operation>(instructions[i].First());
                if (op == Operation.jmp)
                {
                    instructions[i] = new string[] { Operation.nop.ToString(), "0" };
                    return i;
                }
                else if (op == Operation.nop)
                {
                    instructions[i] = new string[] { Operation.jmp.ToString(), instructions[i].Last() };
                    return i;
                }
            }
            throw new InvalidOperationException("Puzzle was not solved");
        }
    }
}
