using System.Collections.Generic;

namespace GameOfLife
{
    public class GridBuilder
    {
        public Grid CreateGrid(int width, int height)
        {
            int totalNumberOfCells = width * height;
            List<Cell> cells = CreateCells(totalNumberOfCells);
            return new Grid(width, height, cells);
        }

        private List<Cell> CreateCells(int numberOfCells)
        {
            List<Cell> cells = new List<Cell>();
            
            for (int i = 1; i <= numberOfCells; i++)
            {
                Cell newCell = new Cell();
                cells.Add(newCell);
            }

            return cells;
        }
    }
}