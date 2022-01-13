using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GenerationUpdater
    {
        public GenerationInfo GetNextGeneration(Grid grid)
        {
            List<Cell> currentLivingCells = GetLivingCells(grid);
            
            List<CellPosition> cellPositions = grid.Cells
                .Where(cell => GetNumberOfRequiredNeighbours(cell).Contains(GetNumberOfLivingNeighbours(cell, currentLivingCells)))
                .Select(cell => new CellPosition(cell.Position))
                .ToList();
            
            return new GenerationInfo(grid.Width, grid.Height, cellPositions);
        }
        
        public List<Cell> GetLivingCells(Grid grid)
        {
            List<Cell> livingCells = grid.Cells.Where(cell => cell.IsAlive).ToList();
            
            return livingCells;
        }

        public int GetNumberOfLivingNeighbours(Cell cell, List<Cell> livingCells)
        {
            List<int> livingCellPositions = livingCells.Select(x => x.Position).ToList();

            int numberOfLivingNeighbours = cell.Neighbours.Count(cellPosition => livingCellPositions.Contains(cellPosition.Number));

            return numberOfLivingNeighbours;
        }

        private List<int> GetNumberOfRequiredNeighbours(Cell cell)
        {
            List<int> requiredNumberOfNeighbours = new List<int>() {3};

            if (cell.IsAlive)
            {
                requiredNumberOfNeighbours.Add(2);
            }

            return requiredNumberOfNeighbours;
        }
    }
}