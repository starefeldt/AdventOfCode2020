using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class BusStopPuzzle : IPuzzle
    {
        private List<string> _input;
        private const int ExtraMinutes = 100;

        public BusStopPuzzle(string fileName)
        {
            _input = InputHelper.ReadAllLines(fileName).ToList();
        }

        public long Solve()
        {
            var desiredDeparture = int.Parse(_input[0]);
            var timeTable = GetTimetable(desiredDeparture);
            var (Bus, WaitingMinutes) = GetFirstBusFromDesiredDeparture(desiredDeparture, timeTable);
            return Bus * WaitingMinutes;
        }

        private (int Bus, int WaitingMinutes) GetFirstBusFromDesiredDeparture(int desiredDeparture, List<int>[] timeTable)
        {
            var i = desiredDeparture;
            while (i < timeTable.Length)
            {
                var result = timeTable[i];
                if (result.Any())
                {
                    return (result.First(), i - desiredDeparture);
                }
                i++;
            }
            throw new InvalidOperationException("Could not found any bus");
        }

        private List<int>[] GetTimetable(int desiredDeparture)
        {
            var buses = GetBuses();
            var timeTable = new List<int>[desiredDeparture + ExtraMinutes];
            for (int i = 1; i < desiredDeparture + ExtraMinutes; i++)
            {
                timeTable[i] = new List<int>();
                foreach (var bus in buses)
                {
                    var result = i % bus;
                    if (result == 0)
                    {
                        timeTable[i].Add(bus);
                    }
                }
            }
            return timeTable;
        }

        private IEnumerable<int> GetBuses()
        {
            return _input[1]
                .Split(',')
                .Where(b => b != "x")
                .Select(b => int.Parse(b));
        }
    }
}
