using System;

namespace AdventOfCode.Domain.Day_11
{
    public enum CellStatus
    {
        Empty,
        Occupied,
        Floor
    }
    public class Cell
    {
        public CellStatus Status { get; private set; }
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column, CellStatus status)
        {
            Row = row;
            Column = column;
            Status = status;
        }

        public void SetCellStatus(CellStatus status)
        {
            Status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   Row == cell.Row &&
                   Column == cell.Column;
        }
    }
}
