using System.Collections.Generic;

namespace GameOfLife
{
    public interface IOutput
    {
        public void DisplayGrid(Grid grid);
        public void DisplaySelectionGrid(List<int> displayGrid, int activeCell, List<int> selectedCells, int width);
    }
}