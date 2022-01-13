using System.Collections.Generic;

namespace GameOfLife
{
    public class GridBuilder
    {
        public Grid CreateGrid(int width, int height, List<CellPosition> livingCells)
        {
            List<Cell> cells = CreateCells(width, height, livingCells);
            return new Grid(width, height, cells);
        }

        private List<Cell> CreateCells(int width, int height, List<CellPosition> livingCells)
        {
            int numberOfCells = width * height;
            List<Cell> cells = new List<Cell>();
            
            for (int position = 1; position <= numberOfCells; position++)
            {
                bool isAlive = livingCells.Exists(cellPosition => cellPosition.Number == position);
                List<CellPosition> neighbours = CalculateNeighbours(new CellPosition(position), width, height);

                Cell newCell = new Cell(position, isAlive, neighbours);
                cells.Add(newCell);
            }

            return cells;
        }

        public List<CellPosition> CalculateNeighbours(CellPosition position, int width, int height)
        {
            int left = position.Number - 1;
            int right = position.Number + 1;
            int bottom = position.Number + width;
            int bottomRight = position.Number + width + 1;
            int bottomLeft = position.Number + width - 1;
            int top = position.Number - width;
            int topRight = position.Number - width + 1;
            int topLeft = position.Number - width - 1;
            
            //rightSide
            if (position.Number % width == 0)
            {
                right -= width;
                bottomRight -= width;
                topRight -= width;
            }

            //leftSide
            if (position.Number % width == 1)
            {
                left += width;
                bottomLeft += width;
                topLeft += width;
            }

            //top row
            if (position.Number < width)
            {
                top += width * height;
                topLeft += width * height;
                topRight += width * height;
            }

            //bottom row
            if (position.Number > (width * height) - width)
            {
                bottom -= width * height;
                bottomLeft -= width * height;
                bottomRight -= width * height;
            }
            
            List<CellPosition> neighbours = new List<CellPosition>();
            
            neighbours.Add(new CellPosition(left));
            neighbours.Add(new CellPosition(right));
            neighbours.Add(new CellPosition(bottom));
            neighbours.Add(new CellPosition(bottomLeft));
            neighbours.Add(new CellPosition(bottomRight));
            neighbours.Add(new CellPosition(top));
            neighbours.Add(new CellPosition(topLeft));
            neighbours.Add(new CellPosition(topRight));

            return neighbours;
        }
    }
}