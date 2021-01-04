using System;
using System.Collections.Generic;

namespace AdventOfCode.Domain.Day_11
{
    public class DistanceOccupiedAlgorithm : IOccupiedAlgorithm
    {
        public int GetOccupiedCount(Cell cell, List<List<Cell>> grid)
        {
            var occupiedCount = 0;
            var maxRowIndex = grid.Count - 1;
            var maxColumnIndex = grid[0].Count - 1;

            //Up
            occupiedCount += SearchForOccupiedCell(cell, grid,
                (currentRow, _) => currentRow > 0,
                (currentRow, _) => (--currentRow, _));

            //Up + Right
            occupiedCount += SearchForOccupiedCell(cell, grid,
                (currentRow, currentColumn) => currentRow > 0 && currentColumn < maxColumnIndex,
                (currentRow, currentColumn) => (--currentRow, ++currentColumn));

            //Right
            occupiedCount += SearchForOccupiedCell(cell, grid,
                (_, currentColumn) => currentColumn < maxColumnIndex,
                (_, currentColumn) => (_, ++currentColumn));

            //Down + Right
            occupiedCount += SearchForOccupiedCell(cell, grid,
                (currentRow, currentColumn) => currentRow < maxRowIndex && currentColumn < maxColumnIndex,
                (currentRow, currentColumn) => (++currentRow, ++currentColumn));

            //Down
            occupiedCount += SearchForOccupiedCell(cell, grid,
                (currentRow, _) => currentRow < maxRowIndex,
                (currentRow, _) => (++currentRow, _));

            //Down + Left
            occupiedCount += SearchForOccupiedCell(cell, grid,
                (currentRow, currentColumn) => currentRow < maxRowIndex && currentColumn > 0,
                (currentRow, currentColumn) => (++currentRow, --currentColumn));

            //Left
            occupiedCount += SearchForOccupiedCell(cell, grid,
               (_, currentColumn) => currentColumn > 0,
               (_, currentColumn) => (_, --currentColumn));

            //Up + Left
            occupiedCount += SearchForOccupiedCell(cell, grid,
              (currentRow, currentColumn) => currentRow > 0 && currentColumn > 0,
              (currentRow, currentColumn) => (--currentRow, --currentColumn));

            return occupiedCount;
        }

        private int SearchForOccupiedCell(Cell cell, List<List<Cell>> grid,
            Func<int, int, bool> predicate,
            Func<int, int, (int, int)> getCoordinates)
        {
            var currentRow = cell.Row;
            var currentColumn = cell.Column;

            while (predicate(currentRow, currentColumn))
            {
                (currentRow, currentColumn) = getCoordinates(currentRow, currentColumn);
                var currentCell = grid[currentRow][currentColumn];
                if (currentCell.Status == CellStatus.Occupied)
                {
                    return 1;
                }
                else if (currentCell.Status == CellStatus.Empty)
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
