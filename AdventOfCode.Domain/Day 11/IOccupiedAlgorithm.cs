using System.Collections.Generic;

namespace AdventOfCode.Domain.Day_11
{
    public interface IOccupiedAlgorithm
    {
        int GetOccupiedCount(Cell cell, List<List<Cell>> grid);
    }
}
