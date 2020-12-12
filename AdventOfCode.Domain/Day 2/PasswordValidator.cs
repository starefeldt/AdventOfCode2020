using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class PasswordValidator : IPuzzle
    {
        private IEnumerable<string> _input;
        private Func<int, int, char, string, bool> _isPasswordValid;

        public PasswordValidator(string fileName, Func<int, int, char, string, bool> isPasswordValid)
        {
            _input = InputHelper.ReadAllLines(fileName);
            _isPasswordValid = isPasswordValid;
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

                if (_isPasswordValid(int.Parse(range[0]), int.Parse(range[1]), char.Parse(search), password))
                    valid++;
            }
            return valid;
        }
    }
}
