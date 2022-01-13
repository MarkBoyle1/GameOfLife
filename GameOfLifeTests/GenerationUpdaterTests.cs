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

            Grid grid = _gridBuilder.CreateGrid(5, 5, currentLivingCells);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
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

            Grid grid = _gridBuilder.CreateGrid(5, 5, currentLivingCells);

            List<Cell> livingCells = _generationUpdater.GetLivingCells(grid);

            Assert.Contains(livingCells, cell => cell.Position == 7);
            Assert.Contains(livingCells, cell => cell.Position == 8);
            Assert.Contains(livingCells, cell => cell.Position == 9);
        }
    }
}