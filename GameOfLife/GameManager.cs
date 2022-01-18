using System.Collections.Generic;
using System.Linq;

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
            
            return generation.LivingCells.Count == 0;
        }

        private bool CheckForNoChange(GenerationInfo currentGeneration, GenerationInfo previousGeneration)
        {
            List<int> currentGenerationLivingCells = ConvertCellPositionsIntoNumbers(currentGeneration.LivingCells);

            List<int> previousGenerationLivingCells = ConvertCellPositionsIntoNumbers(previousGeneration.LivingCells);
            
            return currentGenerationLivingCells.All(previousGenerationLivingCells.Contains);
        }

        private bool CheckForInfiniteLoop(GenerationInfo currentGeneration, List<GenerationInfo> previousGenerations)
        {
            List<int> currentGenerationLivingCells = ConvertCellPositionsIntoNumbers(currentGeneration.LivingCells);

            foreach (var previousGeneration in previousGenerations)
            {
                List<int> previousGenerationLivingCells =
                    ConvertCellPositionsIntoNumbers(previousGeneration.LivingCells);

                if (currentGenerationLivingCells.All(previousGenerationLivingCells.Contains))
                {
                    return true;
                }
            }

            return false;
        }

        private List<int> ConvertCellPositionsIntoNumbers(List<CellPosition> cellPositions)
        {
            return cellPositions
                .Select(cell => cell.Number)
                .ToList();
        }
    }
}