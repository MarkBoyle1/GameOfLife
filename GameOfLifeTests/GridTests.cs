using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridTests
    {
        private GridBuilder _gridBuilder;

        public GridTests()
        {
            _gridBuilder = new GridBuilder();
        }
        
        [Fact]
        public void given_gridWidthEquals5_and_gridHeightEquals5_when_CreateGrid_then_GridCellsCountEquals25()
        {
            List<CellPosition> livingCells = new List<CellPosition>();
            GenerationInfo generation = new GenerationInfo(5, 5, livingCells);

            Grid grid = _gridBuilder.CreateGrid(generation);
            
            Assert.Equal(25, grid.Cells.Count);
        }
        
        [Fact]
        public void given_LivingCellsListContainsPositionThree_when_CreateGrid_then_GridCellPositionThreeIsAliveEqualsTrue()
        {
            List<CellPosition> livingCells = new List<CellPosition>()
            {
                new CellPosition(3)
            };
            GenerationInfo generation = new GenerationInfo(5, 5, livingCells);

            Grid grid = _gridBuilder.CreateGrid(generation);

            Cell targetCell = grid.Cells.Find(x => x.Position.Number == 3);
            
            Assert.True(targetCell.IsAlive);
        }
        
        [Fact]
        public void given_LivingCellsListCountEqualsThree_when_CreateGrid_then_GridLivingCellsCountEqualsThree()
        {
            List<CellPosition> livingCells = new List<CellPosition>()
            {
                new CellPosition(3),
                new CellPosition(5),
                new CellPosition(10)
            };
            GenerationInfo generation = new GenerationInfo(5, 5, livingCells);

            Grid grid = _gridBuilder.CreateGrid(generation);

            int numberOfLivingCells = grid.Cells.Count(cell => cell.IsAlive);

            Assert.Equal(3, numberOfLivingCells);
        }
    }
}