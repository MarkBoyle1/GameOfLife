using System.Collections.Generic;
using System.Linq;

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

        public int GetNumberofLivingNeighbours(Cell cell, List<Cell> livingCells)
        {
            int numberOfLivingNeighbours = 0;
            List<int> livingCellPositions = livingCells.Select(x => x.Position).ToList();

            foreach (var neighbour in cell.Neighbours)
            {
                if (livingCellPositions.Contains(neighbour.Number))
                {
                    numberOfLivingNeighbours++;
                }
            }

            return numberOfLivingNeighbours;
        }
    }
}