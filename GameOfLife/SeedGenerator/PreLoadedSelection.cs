using System.Collections.Generic;

namespace GameOfLife
{
    public class PreLoadedSelection : ISeedGenerator
    {
        private int _width;
        private int _height;
        private List<CellPosition> _livingCells;
        
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