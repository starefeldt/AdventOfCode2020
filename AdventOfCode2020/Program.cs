using AdventOfCode.Domain;
using AdventOfCode.Domain.Day_9;
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
            var day = Day.Ten_1;
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
                Day.Six_1 => new YesAnswerCounter(InputDir + "day6.txt"),
                Day.Six_2 => new YesForAllAnswerCounter(InputDir + "day6.txt"),
                Day.Seven_1 => new FindShinyBag(InputDir + "day7.txt", (bags) =>
                {
                    var containsShinyGold = 0;
                    foreach (var bag in bags)
                    {
                        if (bag.Value.ContainsAnotherBag("shinygold"))
                        {
                            containsShinyGold++;
                        }
                    }
                    return containsShinyGold;
                }),
                Day.Seven_2 => new FindShinyBag(InputDir + "day7.txt", (bags) =>
                {
                    var shinyGoldBag = bags["shinygold"];
                    var contentCount = 0;
                    shinyGoldBag.GetContentCount(ref contentCount);
                    return contentCount;
                }),
                Day.Eight_1 => new FindFirstRepeatedJump(InputDir + "day8.txt"),
                Day.Eight_2 => new FindFaultedInstruction(InputDir + "day8.txt"),
                Day.Nine_1 => new FindFaultedNumber(InputDir + "day9.txt", new SimpleReturn(), 25),
                Day.Nine_2 => new FindFaultedNumber(InputDir + "day9.txt", new FindSumOfFaultedInPreamble(25), 25),
                Day.Ten_1 => new FindJoltageDifferenceInAdapters(InputDir + "day10.txt"),

                _ => throw new ArgumentException($"Could not return implementation for {nameof(IPuzzle)} with value: {day}"),
            };
        }
    }
}
