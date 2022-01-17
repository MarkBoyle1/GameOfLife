using System;
using System.Threading;

namespace GameOfLife
{
    public class ConsoleOutput : IOutput
    {
        public void DisplayGrid(Grid grid)
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
                
                if (cell.Position % grid.Width == 0)
                {
                    Console.WriteLine();
                }
            }
            
            Thread.Sleep(Constants.TimeBetweenGenerationsInMilliseconds);
        }
    }
}