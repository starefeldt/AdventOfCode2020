using System.Collections.Generic;

namespace AdventOfCode.Domain.Day_11
{
    public class AdjacentOccupiedAlgorithm : IOccupiedAlgorithm
    {
        public int GetOccupiedCount(Cell cell, List<List<Cell>> grid)
        {
            var startRow = cell.Row == 0 ? cell.Row : cell.Row - 1;
            var stopRow = cell.Row == grid.Count - 1 ? cell.Row : cell.Row + 1;
            var startColumn = cell.Column == 0 ? cell.Column : cell.Column - 1;
            var stopColumn = cell.Column == grid[0].Count - 1 ? cell.Column : cell.Column + 1;
            var occupiedCount = 0;

            for (int gridRow = startRow; gridRow <= stopRow; gridRow++)
            {
                for (int gridColumn = startColumn; gridColumn <= stopColumn; gridColumn++)
                {
                    var gridCell = grid[gridRow][gridColumn];
                    if (!gridCell.Equals(cell) &&
                        gridCell.Status == CellStatus.Occupied)
                    {
                        occupiedCount++;
                    }
                }
            }
            return occupiedCount;
        }
    }
}
