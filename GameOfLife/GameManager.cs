using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using GameOfLife.Input;

namespace GameOfLife
{
    public class GameManager
    {
        private IUserInput _input;
        private IOutput _output;
        private List<GenerationInfo> _previousGenerations;
        private ISeedSaver _seedSaver;

        public GameManager(IUserInput input, IOutput output)
        {
            _input = input;
            _output = output;
            _previousGenerations = new List<GenerationInfo>();
            _seedSaver = new JSONSeedSaver();
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

        public void SaveSeedIfRequested(GenerationInfo seedGeneration, List<SavedSeed> savedSeeds)
        {
            _output.DisplayMessage(OutputMessages.WouldYouLikeToSaveTheSeed);
            string response = _input.GetUserInput();

            if (response == Constants.YesResponse)
            {
                _output.DisplayMessage(OutputMessages.AskForNameOfSavedSeed);
                string name = _input.GetUserInput();

                SavedSeed newSeed = new SavedSeed(name, seedGeneration);
                savedSeeds.Add(newSeed);
            }
                
            _seedSaver.SaveSeeds(savedSeeds);
        }
        
        public List<SavedSeed> LoadSavedSeeds()
        {
            string jsonString = File.ReadAllText(Constants.JSONSavedSeedsFilePath);
            List<SavedSeed> seeds = JsonSerializer.Deserialize<List<SavedSeed>>(jsonString);
            return seeds;
        }
    }
}