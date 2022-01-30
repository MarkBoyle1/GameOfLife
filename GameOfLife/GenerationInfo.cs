using System.Collections.Generic;

namespace GameOfLife
{
    public class GenerationInfo
    {
        public string Name { get; set; }
        public int Width { get; }
        public int Height { get; }
        public List<CellPosition> LivingCells { get; }

        public GenerationInfo(int width, int height, List<CellPosition> livingCells)
        {
            Width = width;
            Height = height;
            LivingCells = livingCells;
        }
    }
}