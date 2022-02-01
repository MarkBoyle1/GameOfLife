using System.Collections.Generic;
using System.Linq;
using GameOfLife.Output;

namespace GameOfLife
{
    public class GameManager
    {
        private readonly List<GenerationInfo> _previousGenerations;
        private int _currentGenerationCount;
        private readonly int _generationLimit;
        private readonly IOutput _output;

        public GameManager(IOutput output, int generationLimit = Constants.GenerationLimit)
        {
            _previousGenerations = new List<GenerationInfo>();
            _generationLimit = generationLimit;
            _currentGenerationCount = 0;
            _output = output;
        }
        public bool CheckForGameFinish(GenerationInfo generation)
        {
            _currentGenerationCount++;

            if (generation.LivingCells.Count == 0)
            {
                _output.DisplayMessage(OutputMessages.NoMoreLivingCells);
                return true;
            }
            
            if (_previousGenerations.Count == 0)
            {
                _previousGenerations.Add(generation);
                return false;
            }
            
            if (_currentGenerationCount >= _generationLimit)
            {
                _output.DisplayMessage(OutputMessages.GenerationLimitReached);
                return true;
            }

            if (CheckForNoChange(generation, _previousGenerations.Last()))
            {
                _output.DisplayMessage(OutputMessages.GameEndedFromNoChange);
                return true;
            }

            if (CheckForInfiniteLoop(generation, _previousGenerations))
            {
                _output.DisplayMessage(OutputMessages.InfiniteLoopDetected);
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
            
            return currentGenerationLivingCells.All(previousGenerationLivingCells.Contains) 
                   && currentGenerationLivingCells.Count == previousGenerationLivingCells.Count;        //Checks if the two lists are exactly the same.
        }

        private bool CheckForInfiniteLoop(GenerationInfo currentGeneration, List<GenerationInfo> previousGenerations)
        {
            foreach (var previousGeneration in previousGenerations)
            {
                if (CheckForNoChange(currentGeneration, previousGeneration))
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