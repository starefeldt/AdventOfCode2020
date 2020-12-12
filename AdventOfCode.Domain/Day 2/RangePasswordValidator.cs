using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class RangePasswordValidator : IPuzzle
    {
        private IEnumerable<string> _input;

        public RangePasswordValidator(string fileName)
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

        private bool IsPasswordValid(int min, int max, char search, string password)
        {
            var occurences = password.Where(x => x == search).Count();
            return occurences >= min && occurences <= max;
        }
    }
}
