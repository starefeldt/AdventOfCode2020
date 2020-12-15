using AdventOfCode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Program
    {
        private const string InputDir = @"C:\Users\stare\Documents\Visual studio - egna program\AdventOfCode2020\Inputs\";

        static void Main(string[] args)
        {
            var day = Day.Five_2;
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
                Day.Two_1 => new PasswordValidator(InputDir + "day2.txt", (min, max, search, password) =>
                {
                    var occurences = password.Where(x => x == search).Count();
                    return occurences >= min && occurences <= max;
                }),
                Day.Two_2 => new PasswordValidator(InputDir + "day2.txt", (firstPos, secondPos, search, password) =>
                {
                    if ((password[firstPos - 1] != search && password[secondPos - 1] != search) ||
                        (password[firstPos - 1] == search && password[secondPos - 1] == search))
                    {
                        return false;
                    }
                    return true;
                }),
                Day.Three_1 => new TraverseMapAndFindTrees(InputDir + "day3.txt", new List<SlopeData> 
                { 
                    new SlopeData { Right = 3, Down = 1 } 
                }),
                Day.Three_2 => new TraverseMapAndFindTrees(InputDir + "day3.txt", new List<SlopeData>
                {
                    new SlopeData { Right = 1, Down = 1 },
                    new SlopeData { Right = 3, Down = 1 },
                    new SlopeData { Right = 5, Down = 1 },
                    new SlopeData { Right = 7, Down = 1 },
                    new SlopeData { Right = 1, Down = 2 },
                }),
                Day.Four_1 => new SimplePassportValidator(InputDir + "day4.txt"),
                Day.Four_2 => new AdvancedPassportValidator(InputDir + "day4.txt"),
                Day.Five_1 => new AirlineBooking(InputDir + "day5.txt", seatIds => seatIds.Max()),
                Day.Five_2 => new AirlineBooking(InputDir + "day5.txt", seatIds =>
                {
                    var mySeat = 0;
                    seatIds.OrderBy(s => s).Aggregate((a, b) =>
                    {
                        if (b - a != 1)
                        {
                            mySeat = a + 1;
                        }
                        return b;
                    });
                    return mySeat;
                }),

                _ => throw new ArgumentException($"Could not return implementation for {nameof(IPuzzle)} with value: {day}"),
            };
        }
    }
}
