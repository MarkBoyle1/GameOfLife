using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }
        public List<Cell> Cells { get; }
        public Grid(int width, int height, List<Cell> cells)
        {
            Width = width;
            Height = height;
            Cells = cells;
        }
    }
}