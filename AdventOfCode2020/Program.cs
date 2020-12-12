using AdventOfCode.Domain;
using System;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        private const string InputDir = @"C:\Users\stare\Documents\Visual studio - egna program\AdventOfCode2020\Inputs\";

        static void Main(string[] args)
        {
            var day = Day.Two_1;
            var puzzle = GetPuzzle(day);
            var result = puzzle.Solve();
            Console.WriteLine($"The answer to {nameof(Day)}:{day} is {result}");
        }

        private static IPuzzle GetPuzzle(Day day)
        {
            return day switch
            {
                Day.One_1 => new FindTwoNumbersWithSumOf2020_MultipleThem(InputDir + "day1.txt"),
                Day.One_2 => new FindThreeNumbersWithSumOf2020_MultipleThem(InputDir + "day1.txt"),
                Day.Two_1 => new PasswordValidator(InputDir + "day2.txt",(min, max, search, password) => {
                    var occurences = password.Where(x => x == search).Count();
                    return occurences >= min && occurences <= max;
                }),
                Day.Two_2 => new PasswordValidator(InputDir + "day2.txt", (firstPos, secondPos, search, password) => {
                    if ((password[firstPos - 1] != search && password[secondPos - 1] != search) ||
                        (password[firstPos - 1] == search && password[secondPos - 1] == search))
                    {
                        return false;
                    }
                    return true;
                }),

                _ => throw new ArgumentException($"Could not return implementation for {nameof(IPuzzle)} with value: {day}"),
            };
        }
    }
}
