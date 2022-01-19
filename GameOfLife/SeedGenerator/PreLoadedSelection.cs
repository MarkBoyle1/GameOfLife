using System.Collections.Generic;

namespace GameOfLife
{
    public class PreLoadedSelection : ISeedGenerator
    {
        private int _width;
        private int _height;
        private List<CellPosition> _livingCells;
        
        public PreLoadedSelection(SavedSeed savedSeed)
        {
            _width = savedSeed.SeedInfo.Width;
            _height = savedSeed.SeedInfo.Height;
            _livingCells = savedSeed.SeedInfo.LivingCells;
        }
        public int GetGridWidth()
        {
            return _width;
        }

        public int GetGridHeight()
        {
            return _height;
        }

        public int MoveActiveCell(int activeCell, int width, int height)
        {
            return 1;
        }

        public List<CellPosition> GetPositionsOfLivingCells(int width, int height)
        {
            return _livingCells;
        }
    }
}