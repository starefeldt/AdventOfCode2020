using System;

namespace AdventOfCode.Domain.Day_12
{
    public class ShipInstruction
    {
        public Code Code { get; }
        public int Unit { get; }

        public ShipInstruction(Code code, int unit)
        {
            Code = code;
            Unit = unit;
        }
    }

    public class Point
    {
        public int NorthSouth { get; set; }
        public int EastWest { get; set; }

    }
}
