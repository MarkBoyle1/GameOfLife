using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GenerationUpdater
    {
        public GenerationInfo GetNextGeneration(Grid grid)
        {
            List<Cell> currentLivingCells = grid.Cells
                .Where(cell => cell.IsAlive)
                .ToList();
            
            List<Cell> cellsToCheck = GetCellsToCheck(grid, currentLivingCells);

            List<CellPosition> nextGenerationLivingCellPositions = cellsToCheck
                .Where(cell => CheckIfCellLivesInNextGeneration(cell, currentLivingCells))
                .Select(cell => cell.Position)
                .ToList();
            
            return new GenerationInfo(grid.Width, grid.Height, nextGenerationLivingCellPositions);
        }

        private List<Cell> GetCellsToCheck(Grid grid, List<Cell> livingCells)
        {
            List<CellPosition> livingCellsPositions = livingCells.Select(cell => cell.Position).ToList();

            List<CellPosition> neighboursOfLivingCells = new List<CellPosition>();
            livingCells.ForEach(cell => neighboursOfLivingCells.AddRange(cell.Neighbours));
            
            List<CellPosition> cellsToCheck = new List<CellPosition>();
            cellsToCheck.AddRange(livingCellsPositions);
            cellsToCheck.AddRange(neighboursOfLivingCells);

            List<int> cellsToCheckNumbers = cellsToCheck
                .Select(cell => cell.Number)
                .Distinct()
                .ToList();

            List<Cell> cells = grid.Cells.Where(cell => cellsToCheckNumbers.Contains(cell.Position.Number)).ToList();

            return cells;
        }

        private bool CheckIfCellLivesInNextGeneration(Cell cell, List<Cell> currentLivingCells)
        {
            List<int> livingCellPositions = currentLivingCells.Select(x => x.Position.Number).ToList();

            int numberOfLivingNeighbours = cell.Neighbours.Count(cellPosition => livingCellPositions.Contains(cellPosition.Number));
            
            List<int> requiredNumberOfNeighbours = new List<int>() {3};

            if (cell.IsAlive)
            {
                requiredNumberOfNeighbours.Add(2);
            }
            
            return requiredNumberOfNeighbours.Contains(numberOfLivingNeighbours);
        }
    }
}