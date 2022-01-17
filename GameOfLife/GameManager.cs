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
            if (_previousGenerations.Count > 0 && CheckForNoChange(generation, _previousGenerations.First()))
            {
                _previousGenerations.Clear();
                return true;
            }
            _previousGenerations.Add(generation);
            
            return generation.LivingCells.Count == 0;
        }

        private bool CheckForNoChange(GenerationInfo currentGeneration, GenerationInfo previousGeneration)
        {
            List<int> currentGenerationLivingCells = currentGeneration.LivingCells
                .Select(cell => cell.Number)
                .ToList();
            
            List<int> previousGenerationLivingCells = previousGeneration.LivingCells
                .Select(cell => cell.Number)
                .ToList();

            return currentGenerationLivingCells.All(previousGenerationLivingCells.Contains);
        }
    }
}