﻿using AdventOfCode.Domain;
using System;

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
                Day.Two_1 => new PasswordValidator(InputDir + "day2.txt"),

                _ => throw new ArgumentException($"Could not return implementation for {nameof(IPuzzle)} with value: {day}"),
            };
        }
    }
}
