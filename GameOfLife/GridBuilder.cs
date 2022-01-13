using System.Collections.Generic;

namespace GameOfLife
{
    public class GridBuilder
    {
        public Grid CreateGrid(int width, int height, List<CellPosition> livingCells)
        {
            int totalNumberOfCells = width * height;
            List<Cell> cells = CreateCells(totalNumberOfCells, livingCells);
            return new Grid(width, height, cells);
        }

        private List<Cell> CreateCells(int numberOfCells, List<CellPosition> livingCells)
        {
            List<Cell> cells = new List<Cell>();
            
            for (int i = 1; i <= numberOfCells; i++)
            {
                bool isAlive = livingCells.Exists(x => x.Number == i);
                
                Cell newCell = new Cell(i, isAlive);
                cells.Add(newCell);
            }

            return cells;
        }
    }
}