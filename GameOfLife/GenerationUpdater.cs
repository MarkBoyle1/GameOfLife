using System.Collections.Generic;

namespace GameOfLife
{
    public class GenerationUpdater
    {
        public GenerationInfo GetNextGeneration(Grid grid)
        {
            List<CellPosition> cellPositions = new List<CellPosition>();
            return new GenerationInfo(grid.Width, grid.Height, cellPositions);
        }
        
        public List<Cell> GetLivingCells(Grid grid)
        {
            List<Cell> livingCells = new List<Cell>();

            foreach (var cell in grid.Cells)
            {
                if (cell.IsAlive)
                {
                    livingCells.Add(cell);
                }
            }

            return livingCells;
        }
    }
}