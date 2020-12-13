using AdventOfCode.Utility;
using System.Collections.Generic;

namespace AdventOfCode.Domain
{
    public class PassportValidator : IPuzzle
    {
        private IEnumerable<string> _input;

        public PassportValidator(string fileName)
        {
            _input = InputHelper.ReadAllTextAndSplitOn(fileName, System.Environment.NewLine + System.Environment.NewLine);
        }

        public long Solve()
        {
            var valid = 0;
            foreach (var data in _input)
            {
                var blankSpaceSeperated = data.Replace(System.Environment.NewLine, " ");
                var passportData = blankSpaceSeperated.Split(' ');
                if (passportData.Length == 8)
                {
                    valid++;
                }
                else if (passportData.Length == 7)
                {
                    var validator = GetCleanValidator;
                    foreach (var pData in passportData)
                    {
                        var key = pData.Split(':')[0];
                        validator[key] = true;
                    }
                    if(validator["cid"] == false)
                    {
                        valid++;
                    }
                }
            }
            return valid;
        }

        private Dictionary<string, bool> GetCleanValidator => new Dictionary<string, bool>
        {
            {"byr", false },
            {"iyr", false },
            {"eyr", false },
            {"hgt", false },
            {"hcl", false },
            {"ecl", false },
            {"pid", false },
            {"cid", false },
        };
    }
}
