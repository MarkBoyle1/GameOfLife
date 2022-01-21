using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GenerationUpdater
    {
        public GenerationInfo GetNextGeneration(Grid grid)
        {
            List<Cell> currentLivingCells = GetLivingCells(grid);
            List<Cell> cellsToCheck = GetCellsToCheck(grid);

            List<CellPosition> cellPositions = cellsToCheck
                .Where(cell => GetNumberOfRequiredNeighbours(cell).Contains(GetNumberOfLivingNeighbours(cell, currentLivingCells)))
                .Select(cell => new CellPosition(cell.Position.Number))
                .ToList();
            
            return new GenerationInfo(grid.Width, grid.Height, cellPositions);
        }
        
        private List<Cell> GetLivingCells(Grid grid)
        {
            List<Cell> livingCells = grid.Cells.Where(cell => cell.IsAlive).ToList();
            
            return livingCells;
        }

        private List<Cell> GetCellsToCheck(Grid grid)
        {
            List<Cell> livingCells = GetLivingCells(grid);
            List<CellPosition> livingCellsPositions = GetLivingCells(grid).Select(cell => cell.Position).ToList();

            List<CellPosition> cellsToCheck = new List<CellPosition>(livingCellsPositions);

            livingCells.ForEach(cell => cell.Neighbours.ForEach(cellPosition => cellsToCheck.Add(cellPosition)));

            List<int> numbers = cellsToCheck
                .Select(cell => cell.Number)
                .Distinct()
                .ToList();

            List<Cell> cells = grid.Cells.Where(cell => numbers.Contains(cell.Position.Number)).ToList();

            return cells;
        }

        private int GetNumberOfLivingNeighbours(Cell cell, List<Cell> livingCells)
        {
            List<int> livingCellPositions = livingCells.Select(x => x.Position.Number).ToList();

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