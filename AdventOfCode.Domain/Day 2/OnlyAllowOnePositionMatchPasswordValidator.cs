using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class OnlyAllowOnePositionMatchPasswordValidator : IPuzzle
    {
        private IEnumerable<string> _input;

        public OnlyAllowOnePositionMatchPasswordValidator(string fileName)
        {
            _input = InputHelper.ReadAllLines(fileName);
        }

        public int Solve()
        {
            var valid = 0;
            foreach (var instruction in _input)
            {
                var parts = instruction.Split(' ');
                var range = parts[0].Split('-');
                var search = parts[1].Replace(":", "");
                var password = parts[2];

                if (IsPasswordValid(int.Parse(range[0]), int.Parse(range[1]), char.Parse(search), password))
                    valid++;
            }
            return valid;
        }

        private bool IsPasswordValid(int firstPos, int secondPos, char search, string password)
        {
            if((password[firstPos - 1] != search && password[secondPos - 1] != search) ||
               (password[firstPos - 1] == search && password[secondPos - 1] == search))
            {
                return false;
            }
            return true;
        }
    }
}
