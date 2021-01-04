using AdventOfCode.Domain.Day_11;
using AdventOfCode.Utility;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Domain
{
    public class AirplaneSeater : IPuzzle
    {
        private List<string> _input;
        private List<List<Cell>> _grid;
        private readonly int _maxAllowedOccupied;
        private readonly IOccupiedAlgorithm _algorithm;

        public AirplaneSeater(string fileName, int maxAllowedOccupied, IOccupiedAlgorithm algorithm)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .ToList();
            _grid = CreateGridFromInput();
            _maxAllowedOccupied = maxAllowedOccupied;
            _algorithm = algorithm;
        }

        public long Solve()
        {
            var gridIsChanged = true;
            while (gridIsChanged)
            {
                gridIsChanged = false;
                var tempGrid = CreateDeepCopyOfGrid(_grid);
                for (int row = 0; row < tempGrid.Count; row++)
                {
                    var gridRow = tempGrid[row];
                    for (int column = 0; column < gridRow.Count; column++)
                    {
                        var cell = gridRow[column];
                        if (TrySetStatusFor(cell))
                        {
                            gridIsChanged = true;
                        }
                    }
                }
                _grid = tempGrid;
            }
            var sum = 0;
            foreach (var row in _grid)
            {
                sum += row.Where(c => c.Status == CellStatus.Occupied).Count();
            }
            return sum;
        }

        private bool TrySetStatusFor(Cell cell)
        {
            var occupied = _algorithm.GetOccupiedCount(cell, _grid);

            if (cell.Status == CellStatus.Empty)
            {
                if (occupied == 0)
                {
                    cell.SetCellStatus(CellStatus.Occupied);
                    return true;
                }
            }
            else if (cell.Status == CellStatus.Occupied)
            {
                if(occupied >= _maxAllowedOccupied)
                {
                    cell.SetCellStatus(CellStatus.Empty);
                    return true;
                }
            }
            return false;
        }

        private List<List<Cell>> CreateGridFromInput()
        {
            var grid = new List<List<Cell>>();
            for (int row = 0; row < _input.Count; row++)
            {
                var inputRow = _input[row];
                var cells = new List<Cell>();
                for (int column = 0; column < inputRow.Length; column++)
                {
                    var inputColumn = inputRow[column];
                    CellStatus status = CellStatus.Empty;
                    if (inputColumn == '.')
                    {
                        status = CellStatus.Floor;
                    }
                    else if (inputColumn == '#')
                    {
                        status = CellStatus.Occupied;
                    }
                    cells.Add(new Cell(row, column, status));
                }
                grid.Add(cells);
            }
            return grid;
        }

        private List<List<Cell>> CreateDeepCopyOfGrid(List<List<Cell>> grid)
        {
            var copy = new List<List<Cell>>();
            foreach (var row in grid)
            {
                var rowCopy = new List<Cell>();
                foreach (var cell in row)
                {
                    rowCopy.Add(new Cell(cell.Row, cell.Column, cell.Status));
                }
                copy.Add(rowCopy);
            }
            return copy;
        }
    }
}
