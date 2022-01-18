using System.Collections.Generic;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GenerationUpdaterTests
    {
        private GenerationUpdater _generationUpdater;
        private GridBuilder _gridBuilder;

        public GenerationUpdaterTests()
        {
            _generationUpdater = new GenerationUpdater();
            _gridBuilder = new GridBuilder();
        }

        [Fact]
        public void given_LivingCellsIncludeSevenEightNine_when_GetNextGeneration_then_LivingCellsIncludesEight()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
                new CellPosition(9)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);

            Assert.Contains(nextGeneration.LivingCells, cellPosition => cellPosition.Number == 8);
        }
        
        [Fact]
        public void given_LivingCellsIncludeSevenEightNine_when_GetLivingCells_then_returns_SevenEightNine()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
                new CellPosition(9)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);

            Grid grid = _gridBuilder.CreateGrid(generation);

            List<Cell> livingCells = _generationUpdater.GetLivingCells(grid);

            Assert.Contains(livingCells, cell => cell.Position == 7);
            Assert.Contains(livingCells, cell => cell.Position == 8);
            Assert.Contains(livingCells, cell => cell.Position == 9);
        }
        
        [Fact]
        public void given_PositionEqualsEight_and_LivingCellsIncludeSevenEightNine_when_GetNumberOfLivingNeighbours_then_return_Two()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
                new CellPosition(9)
            };
            
            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);

            Grid grid = _gridBuilder.CreateGrid(generation);

            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);
            List<Cell> livingCells = _generationUpdater.GetLivingCells(grid);

            int numberOfLivingNeighbours = _generationUpdater.GetNumberOfLivingNeighbours(targetCell, livingCells);

            Assert.Equal(2, numberOfLivingNeighbours);
           
        }
    }
}