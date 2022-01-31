using System.Collections.Generic;

namespace GameOfLife.SeedGenerator
{
    public interface ISeedGenerator
    {
        public int GetGridWidth();
        public int GetGridHeight();
        public List<CellPosition> GetPositionsOfLivingCells(int width, int height);
    }
}