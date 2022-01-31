using System.Collections.Generic;

namespace GameOfLife.SeedGenerator
{
    public class PreLoadedSelection : ISeedGenerator
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<CellPosition> _livingCells;
        
        public PreLoadedSelection(GenerationInfo savedSeed)
        {
            _width = savedSeed.Width;
            _height = savedSeed.Height;
            _livingCells = savedSeed.LivingCells;
        }
        public int GetGridWidth()
        {
            return _width;
        }

        public int GetGridHeight()
        {
            return _height;
        }

        public List<CellPosition> GetPositionsOfLivingCells(int width, int height)
        {
            return _livingCells;
        }
    }
}