using System.Collections.Generic;

namespace GameOfLife.Output
{
    public interface IOutput
    {
        public void DisplayGrid(Grid grid);
        public void DisplaySelectionGrid(List<int> displayGrid, int activeCell, List<int> selectedCells, int width);
        public void DisplayMessage(string message);
    }
}