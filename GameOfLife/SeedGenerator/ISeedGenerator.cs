using System.Collections.Generic;

namespace GameOfLife
{
    public interface ISeedGenerator
    {
        public int GetGridWidth();
        public int GetGridHeight();
        public int MoveActiveCell(int activeCell, int width, int height);
        public List<CellPosition> GetPositionsOfLivingCells(int width, int height);
    }
}