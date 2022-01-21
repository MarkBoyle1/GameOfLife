using System.Collections.Generic;
using System.Linq;
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
        public void given_LivingCellsIncludeSevenEightNine_when_GetNextGeneration_then_return_ListContainingEightThreeThirteen()
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
            Assert.Contains(nextGeneration.LivingCells, cellPosition => cellPosition.Number == 3);
            Assert.Contains(nextGeneration.LivingCells, cellPosition => cellPosition.Number == 13);
            Assert.DoesNotContain(nextGeneration.LivingCells, cellPosition => cellPosition.Number == 7);
            Assert.DoesNotContain(nextGeneration.LivingCells, cellPosition => cellPosition.Number == 9);
        }
        
        [Fact]
        public void given_CurrentGenerationContainsTwoLivingCells_when_GetNextGeneration_then_return_NoLivingCells()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            
            Assert.Empty(nextGeneration.LivingCells);
        }
        
        [Fact]
        public void given_CellPositionEightIsDeadAndSurroundedByThreeLivingCells_when_GetNextGeneration_then_CellEightBecomesLiving()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(9),
                new CellPosition(13)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            
            Assert.Contains(nextGeneration.LivingCells, cell => cell.Number == 8);
        }
        
        [Fact]
        public void given_CellPositionEightIsDeadAndSurroundedByTwoLivingCells_when_GetNextGeneration_then_CellEightRemainsDead()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(9)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            grid = _gridBuilder.CreateGrid(nextGeneration);
            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);

            Assert.False(targetCell.IsAlive);
        }
        
        [Fact]
        public void given_CellPositionEightIsDeadAndSurroundedByFourLivingCells_when_GetNextGeneration_then_CellEightRemainsDead()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(9),
                new CellPosition(13),
                new CellPosition(3)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            grid = _gridBuilder.CreateGrid(nextGeneration);
            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);

            Assert.False(targetCell.IsAlive);
        }
        
        [Fact]
        public void given_CellPositionEightIsAliveAndSurroundedByTwoLivingCells_when_GetNextGeneration_then_CellEightRemainsAlive()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
                new CellPosition(9),
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            grid = _gridBuilder.CreateGrid(nextGeneration);
            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);

            Assert.True(targetCell.IsAlive);
        }
        
        [Fact]
        public void given_CellPositionEightIsAliveAndSurroundedByThreeLivingCells_when_GetNextGeneration_then_CellEightRemainsAlive()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
                new CellPosition(9),
                new CellPosition(13)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            grid = _gridBuilder.CreateGrid(nextGeneration);
            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);

            Assert.True(targetCell.IsAlive);
        }
        
        [Fact]
        public void given_CellPositionEightIsAliveAndSurroundedByFourLivingCells_when_GetNextGeneration_then_CellEightBecomesDead()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
                new CellPosition(9),
                new CellPosition(13),
                new CellPosition(3)
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            grid = _gridBuilder.CreateGrid(nextGeneration);
            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);

            Assert.False(targetCell.IsAlive);
        }
        
        [Fact]
        public void given_CellPositionEightIsAliveAndSurroundedByOneLivingCell_when_GetNextGeneration_then_CellEightBecomesDead()
        {
            List<CellPosition> currentLivingCells = new List<CellPosition>()
            {
                new CellPosition(7),
                new CellPosition(8),
            };

            GenerationInfo generation = new GenerationInfo(5, 5, currentLivingCells);
            Grid grid = _gridBuilder.CreateGrid(generation);

            GenerationInfo nextGeneration = _generationUpdater.GetNextGeneration(grid);
            grid = _gridBuilder.CreateGrid(nextGeneration);
            Cell targetCell = grid.Cells.Find(cell => cell.Position == 8);

            Assert.False(targetCell.IsAlive);
        }
    }
}