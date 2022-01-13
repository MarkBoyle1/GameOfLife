using System;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class GridTests
    {
        private GridBuilder _gridBuilder = new GridBuilder();
        
        [Fact]
        public void given_gridWidthEquals5_and_gridHeightEquals5_when_CreateGrid_then_GridCellsCountEquals25()
        {
            int width = 5;
            int height = 5;
            
            Grid grid = _gridBuilder.CreateGrid(width, height);
            
            Assert.Equal(25, grid.Cells.Count);
        }
    }
}