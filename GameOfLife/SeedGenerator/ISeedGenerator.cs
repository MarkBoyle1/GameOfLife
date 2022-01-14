using System.Collections.Generic;

namespace GameOfLife
{
    public interface ISeedGenerator
    {
        public int MoveActiveCell(int activeCell, int width);
        public List<CellPosition> GetPositionsOfLivingCells(int width);
    }
}