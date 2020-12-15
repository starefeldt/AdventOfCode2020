using AdventOfCode.Utility;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Domain
{
    public class AirlineBooking : IPuzzle
    {
        private IEnumerable<string> _input;

        public AirlineBooking(string fileName)
        {
            _input = InputHelper.ReadAllLines(fileName);
        }

        public long Solve()
        {
            int highestSeatId = 0;
            foreach (var instruction in _input)
            {
                int bottomRow = 0;
                int topRow = 127;
                int bottomColumn = 0;
                int topColumn = 7;

                foreach (var letter in instruction)
                {
                    switch (letter)
                    {
                        //raise bottom to midpoint
                        case 'B':
                            bottomRow += GetMidpointValue(topRow, bottomRow);
                            break;
                        case 'R':
                            bottomColumn += GetMidpointValue(topColumn, bottomColumn);
                            break;
                        //drop top to midpoint
                        case 'F':
                            topRow -= GetMidpointValue(topRow, bottomRow);
                            break;
                        case 'L':
                            topColumn -= GetMidpointValue(topColumn, bottomColumn);
                            break;
                    }
                }
                ThrowWhenNotFound(bottomRow, topRow, bottomColumn, topColumn);
                var seatId = bottomRow * 8 + bottomColumn;
                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }
            return highestSeatId;
        }

        private static int GetMidpointValue(int topValue, int bottomValue) => (int)Math.Ceiling((topValue - bottomValue) / 2M);

        private static void ThrowWhenNotFound(int bottomRow, int topRow, int bottomColumn, int topColumn)
        {
            if (bottomRow != topRow)
                throw new InvalidOperationException("Did not find row");
            if (bottomColumn != topColumn)
                throw new InvalidOperationException("Did not find column");
        }
    }
}
