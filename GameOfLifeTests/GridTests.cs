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
            int width = 5;
            int height = 5;
            List<CellPosition> livingCells = new List<CellPosition>();
            
            Grid grid = _gridBuilder.CreateGrid(width, height, livingCells);
            
            Assert.Equal(25, grid.Cells.Count);
        }
        
        [Fact]
        public void given_LivingCellsListContainsThree_when_CreateGrid_then_GridCellPositionThreeIsAliveEqualsTrue()
        {
            int width = 5;
            int height = 5;
            List<CellPosition> livingCells = new List<CellPosition>() {new CellPosition(3)};

            Grid grid = _gridBuilder.CreateGrid(width, height, livingCells);

            Cell targetCell = grid.Cells.Find(x => x.Position == 3);
            
            Assert.True(targetCell.IsAlive);
        }

        [Fact]
        public void
            given_PositionEqualsEight_and_WidthAndHeightEqualFive_when_CalculateNeighbours_then_return_CorrectNeighbours()
        {
            CellPosition position = new CellPosition(8);
            int width = 5;
            int height = 5;
            
            List<CellPosition> acutal = _gridBuilder.CalculateNeighbours( position, width,  height);

            Assert.Contains(acutal, cellPosition => cellPosition.Number == 7);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 9);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 3);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 2);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 4);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 13);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 12);
            Assert.Contains(acutal, cellPosition => cellPosition.Number == 14);
        }
    }
}