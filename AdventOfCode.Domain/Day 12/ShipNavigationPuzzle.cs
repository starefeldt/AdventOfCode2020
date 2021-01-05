using AdventOfCode.Domain.Day_12;
using AdventOfCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class ShipNavigationPuzzle : IPuzzle
    {
        private readonly IShip _ship;
        private List<ShipInstruction> _instructions;

        public ShipNavigationPuzzle(string fileName, IShip ship)
        {
            var input = InputHelper.ReadAllLines(fileName);
            _instructions = input.Select(l => new ShipInstruction(
                Enum.Parse<Code>(l[0].ToString()),
                int.Parse(l.Substring(1)))).ToList();
            _ship = ship;
        }

        public long Solve()
        {
            foreach (var instruction in _instructions)
            {
                switch (instruction.Code)
                {
                    case Code.N:
                        _ship.Steer(Direction.North, instruction.Unit);
                        break;
                    case Code.S:
                        _ship.Steer(Direction.South, instruction.Unit);
                        break;
                    case Code.E:
                        _ship.Steer(Direction.East, instruction.Unit);
                        break;
                    case Code.W:
                        _ship.Steer(Direction.West, instruction.Unit);
                        break;
                    case Code.L:
                        _ship.Turn(Turn.Left, instruction.Unit);
                        break;
                    case Code.R:
                        _ship.Turn(Turn.Right, instruction.Unit);
                        break;
                    case Code.F:
                        _ship.Steer(_ship.Heading, instruction.Unit);
                        break;
                }
            }
            return 
                Math.Abs(_ship.Position.NorthSouth) +
                Math.Abs(_ship.Position.EastWest);
        }
    }
}
