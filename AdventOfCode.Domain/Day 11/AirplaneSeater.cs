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

        public AirplaneSeater(string fileName)
        {
            _input = InputHelper
                .ReadAllLines(fileName)
                .ToList();
            _grid = CreateGridFromInput();
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
            var occupied = GetOccupiedCount(cell);

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
                if(occupied >= 4)
                {
                    cell.SetCellStatus(CellStatus.Empty);
                    return true;
                }
            }
            return false;
        }

        private int GetOccupiedCount(Cell cell)
        {
            var startRow = cell.Row == 0 ? cell.Row : cell.Row - 1;
            var stopRow = cell.Row == _grid.Count - 1 ? cell.Row : cell.Row + 1;
            var startColumn = cell.Column == 0 ? cell.Column : cell.Column - 1;
            var stopColumn = cell.Column == _grid[0].Count - 1 ? cell.Column : cell.Column + 1;
            var occupiedCount = 0;

            for (int gridRow = startRow; gridRow <= stopRow; gridRow++)
            {
                for (int gridColumn = startColumn; gridColumn <= stopColumn; gridColumn++)
                {
                    var gridCell = _grid[gridRow][gridColumn];
                    if (!gridCell.Equals(cell) &&
                        gridCell.Status == CellStatus.Occupied)
                    {
                        occupiedCount++;
                    }
                }
            }
            return occupiedCount;
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
