using System.Collections.Generic;
using System.Linq;
using GameOfLife.Input;

namespace GameOfLife
{
    public class GameManager
    {
        private List<GenerationInfo> _previousGenerations;

        public GameManager()
        {
            _previousGenerations = new List<GenerationInfo>();
        }
        public bool CheckForGameFinish(GenerationInfo generation)
        {
            if (generation.LivingCells.Count == 0)
            {
                return true;
            }
            
            if (_previousGenerations.Count == 0)
            {
                _previousGenerations.Add(generation);
                return false;
            }
            
            if (CheckForNoChange(generation, _previousGenerations.Last()))
            {
                _previousGenerations.Add(generation);
                return true;
            }

            if (CheckForInfiniteLoop(generation, _previousGenerations))
            {
                _previousGenerations.Add(generation);
                return true;
            }
            
            _previousGenerations.Add(generation);

            if (_previousGenerations.Count > Constants.NumberOfPreviousGenerationsKeptToCheckForInfiniteLoop)
            {
                _previousGenerations.RemoveAt(0);
            }
            
            return false;
        }

        private bool CheckForNoChange(GenerationInfo currentGeneration, GenerationInfo previousGeneration)
        {
            List<int> currentGenerationLivingCells = ConvertCellPositionsIntoIntegers(currentGeneration.LivingCells);
            List<int> previousGenerationLivingCells = ConvertCellPositionsIntoIntegers(previousGeneration.LivingCells);
            
            return currentGenerationLivingCells.All(previousGenerationLivingCells.Contains);
        }

        private bool CheckForInfiniteLoop(GenerationInfo currentGeneration, List<GenerationInfo> previousGenerations)
        {
            List<int> currentGenerationLivingCells = ConvertCellPositionsIntoIntegers(currentGeneration.LivingCells);

            foreach (var previousGeneration in previousGenerations)
            {
                List<int> previousGenerationLivingCells =
                    ConvertCellPositionsIntoIntegers(previousGeneration.LivingCells);

                if (currentGenerationLivingCells.All(previousGenerationLivingCells.Contains))
                {
                    return true;
                }
            }

            return false;
        }

        private List<int> ConvertCellPositionsIntoIntegers(List<CellPosition> cellPositions)
        {
            return cellPositions
                .Select(cell => cell.Number)
                .ToList();
        }
    }
}