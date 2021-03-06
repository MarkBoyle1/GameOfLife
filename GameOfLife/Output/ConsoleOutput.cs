using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife.Output
{
    public class ConsoleOutput : IOutput
    {
        public void DisplayGrid(Grid grid, int sleepPeriod = Constants.TimeBetweenGenerationsInMilliseconds)
        {
            Console.Clear();
            foreach (var cell in grid.Cells)
            {
                if (cell.IsAlive)
                {
                    Console.Write(Constants.LivingCell);
                }
                else
                {
                    Console.Write(Constants.DeadCell);
                }
                
                if (cell.Position.Number % grid.Width == 0)
                {
                    Console.WriteLine();
                }
            }
            
            Thread.Sleep(sleepPeriod);
        }

        public void DisplaySelectionGrid(List<int> displayGrid, int activeCell, List<int> selectedCells, int width)
        {
            Console.Clear();
                
            foreach (var cell in displayGrid)
            {
                    
                if (cell == activeCell && selectedCells.Contains(cell))
                {
                    Console.ForegroundColor = Constants.ActiveCellColour;
                    Console.Write(Constants.SelectedActiveCell);
                }
                else if (cell == activeCell)
                {
                    Console.ForegroundColor = Constants.ActiveCellColour;
                    Console.Write(Constants.DeselectedActiveCell);
                }
                else if (selectedCells.Contains(cell))
                {
                    Console.ForegroundColor = Constants.SelectedCellColour;
                    Console.Write(Constants.SelectedCell);
                }
                else
                {
                    Console.ForegroundColor = Constants.DefaultColour;
                    Console.Write(Constants.DeselectedCell);
                }
                    
                if (cell % width == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}