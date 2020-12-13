using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain
{
    public class AdvancedPassportValidator : IPuzzle
    {
        private IEnumerable<string> _input;

        public AdvancedPassportValidator(string fileName)
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
                if (passportData.Length == 8 || 
                   (passportData.Length == 7 && CidIsMissing(passportData)))
                {
                    if(IsPassportValid(passportData))
                    {
                        valid++;
                    }
                }
            }
            return valid;
        }

        private static bool CidIsMissing(string[] passportData)
        {
            return !passportData.Any(p => p.Split(':')[0] == "cid");
        }

        private bool IsPassportValid(string[] passportData)
        {
            var validator = GetValidator;
            foreach (var pData in passportData)
            {
                var keyValue = pData.Split(':');
                var key = keyValue[0];
                var value = keyValue[1];
                var rule = validator[key];
                if (!rule(value))
                {
                    return false;
                }
            }
            return true;
        }

        private Dictionary<string, Func<string, bool>> GetValidator => new Dictionary<string, Func<string, bool>>
        {
            { "byr", (value) => int.Parse(value) >= 1920 && int.Parse(value) <= 2002 },
            { "iyr", (value) => int.Parse(value) >= 2010 && int.Parse(value) <= 2020 },
            { "eyr", (value) => int.Parse(value) >= 2020 && int.Parse(value) <= 2030 },
            { "hgt", (value) =>
                {
                    if(value.Contains("cm"))
                    {
                        var number = value.Replace("cm", "");
                        var height = int.Parse(number);
                        return height >= 150 && height <= 193;
                    }
                    else if(value.Contains("in"))
                    {
                        var number = value.Replace("in", "");
                        var height = int.Parse(number);
                        return height >= 59 && height <= 76;
                    }
                    return false;
                }
            },
            {"hcl", (value) => Regex.Match(value, @"^#[0-9a-f]{6}$").Success },  //match 7 characters: # followed by 0-9 OR a-f
            {"ecl", (value) =>
                {
                    return
                    value == "amb" ||
                    value == "blu" ||
                    value == "brn" ||
                    value == "gry" ||
                    value == "grn" ||
                    value == "hzl" ||
                    value == "oth";
                }
            },
            {"pid", (value) => value.Length == 9},
            {"cid", (value) => true },
        };
    }
}
