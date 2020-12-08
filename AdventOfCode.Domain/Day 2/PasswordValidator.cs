using AdventOfCode.Domain.Day_2;
using AdventOfCode.Utility;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Domain
{
    public class PasswordValidator : IPuzzle
    {
        private IEnumerable<string> _input;

        public PasswordValidator(string fileName)
        {
            _input = InputHelper.ReadAllLines(fileName);
        }

        public int Solve()
        {
            var instructions = new List<Instruction>();
            foreach (var instruction in _input)
            {
                var parts = instruction.Split(' ');
                var range = parts[0].Split('-');
                var search = parts[1].Replace(":", "");
                var password = parts[2];

                instructions.Add(new Instruction(int.Parse(range[0]), int.Parse(range[1]), char.Parse(search), password));
            }
            var valid = 0;
            foreach (var instruction in instructions)
            {
                if (instruction.IsPasswordValid())
                    valid++;
            }
            return valid;
        }
    }

}
