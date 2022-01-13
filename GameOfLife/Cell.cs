using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        public int Position;
        public bool IsAlive { get; }
        public List<CellPosition> Neighbours { get; }

        public Cell(int position, bool isAlive, List<CellPosition> neighbours)
        {
            Position = position;
            IsAlive = isAlive;
            Neighbours = neighbours;
        }
    }
}